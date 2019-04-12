using HotelWeb.Context;
using HotelWeb.Data.Repositories.Interfaces;
using HotelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWeb.Data.Repositories
{
    public class VisitorRepository : BaseRepository<Visitor>, IVisitorRepository
    {
        public VisitorRepository(HotelDbContext context) : base(context)
        {

        }
    }
}