using HotelWeb.Models;
using HotelWeb.Models.Requests;
using HotelWeb.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWeb.Data.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<UserRequest> Login(UserRequest request);
        Task<List<User>> GetAllUsersWithRoles();
    }
}
