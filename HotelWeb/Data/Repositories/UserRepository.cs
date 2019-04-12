using System;
using HotelWeb.Context;
using HotelWeb.Data.Repositories.Interfaces;
using HotelWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelWeb.Security;
using HotelWeb.Models.Requests;

namespace HotelWeb.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly HotelDbContext _context;
        private readonly SecuritySetting _securitySetting;

        public UserRepository(IOptions<SecuritySetting> setting, HotelDbContext context) : base(context)
        {
            _securitySetting = setting.Value;
            _context = context;
        }
        
        public async Task<UserRequest> Login(UserRequest request)
        {
            var hash = _securitySetting.GetHash(request.Password);
            var user = await _context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Login == request.Login && x.Password == hash);

            if (user == null)
                return null;

            var result = new UserRequest
            {
                Name = user.Name,
                Surname = user.Surname,
                Patronymic = user.Patronymic,
                Login = user.Login,
                Role = user.Role.Name
            };

            result.Token = _securitySetting.GetToken(result);

            return result;
        }

        public async Task<List<User>> GetAllUsersWithRoles()
        {
            return await Task.Run(()=> _context.Users.Include(x => x.Role).ToListAsync());
        }
    }
}
