using HotelWeb.Context;
using HotelWeb.Data.Repositories.Interfaces;
using HotelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWeb.Data.Repositories
{
    public class UserVisitorRepository : BaseRepository<UserVisitor>, IUserVisitorRepository
    {
        public UserVisitorRepository(HotelDbContext context) : base(context)
        {

        }
    }
}