using HotelWeb.Context;
using HotelWeb.Data.Repositories.Interfaces;
using HotelWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWeb.Data.Repositories
{
    public class ApartmentTypeRepository : BaseRepository<ApartmentType>, IApartmentTypeRepository
    {
        public ApartmentTypeRepository(HotelDbContext context) : base(context)
        {

        }
    }
}
