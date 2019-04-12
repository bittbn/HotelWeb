using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelWeb.Data.Repositories.Interfaces;
using HotelWeb.Models;
using HotelWeb.Models.Requests;
using HotelWeb.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelWeb.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public AccountsController(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpGet]
        public async Task<List<User>> Get()
        {
            return await Task.Run(() => _userRepository.GetAll().Result); 
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody]UserRequest request)
        {
            var user = _userRepository.Login(request).Result;

            if (user == null)
                return BadRequest("Username or password is incorrect.");

            user.Password = null;

            return Ok(user);
        }

        [Authorize(Roles = "SuperAdmin, Admin")]
        [HttpPost("registration")]
        public IActionResult Registration([FromBody]UserRequest request)
        {
            if (request.Role=="SuperAdmin")
                return BadRequest("Only one SuperAdmin.");

            if (_userRepository.Any(x => x.Login == request.Login).Result)
                return BadRequest("Login exists.");

            var user = new User()
            {
                Name = request.Name,
                Surname = request.Surname,
                Patronymic = request.Patronymic,
                Login = request.Login,
                Password = new SecuritySetting().GetHash(request.Password),
                RoleId = _roleRepository.GetIdByRoleName(request.Role).Result
            };

            try
            {
                _userRepository.Create(user);
                _userRepository.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            user.Role = null;
            user.Password = Guid.Empty;

            return Ok(user);
        }
    }
}
