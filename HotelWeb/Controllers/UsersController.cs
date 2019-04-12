using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelWeb.Data.Repositories;
using HotelWeb.Data.Repositories.Interfaces;
using HotelWeb.Models;
using HotelWeb.Models.Requests;
using HotelWeb.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelWeb.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly SecuritySetting _securitySetting;

        public UsersController(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<List<User>> Get()
        {
           return await _userRepository.GetAll();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await _userRepository.GetById(id);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserRequest userNew)
        {
            var oldUser = _userRepository.GetAllUsersWithRoles().Result
                .Where(x => x.Id == id)
                .SingleOrDefault();

            if (oldUser == null)
                return NotFound();

            try
            {
                oldUser.Name = userNew.Name;
                oldUser.Surname = userNew.Surname;
                oldUser.Patronymic = userNew.Patronymic;
                oldUser.Password = _securitySetting.GetHash(userNew.Password);
                oldUser.Login = userNew.Login;
                oldUser.Role.Name = userNew.Role;
                oldUser.RoleId = _roleRepository.GetIdByRoleName(userNew.Role).Result;

                _userRepository.Update(oldUser);
                _userRepository.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userRepository.GetById(id).Result;

            if (user == null)
                return NotFound();

            try
            {
                _userRepository.Delete(user);
                _userRepository.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
