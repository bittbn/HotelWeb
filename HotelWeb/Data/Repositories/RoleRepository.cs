using HotelWeb.Context;
using HotelWeb.Data.Repositories.Interfaces;
using HotelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HotelWeb.Data.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private readonly HotelDbContext _context;

        public RoleRepository(HotelDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> GetIdByRoleName(string name)
        {
            return await Task.Run(()=> _context.Roles.FirstOrDefault(x => x.Name == name).Id);
        }
    }
}
