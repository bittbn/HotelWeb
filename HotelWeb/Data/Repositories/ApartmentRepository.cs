using HotelWeb.Context;
using HotelWeb.Data.Repositories.Interfaces;
using HotelWeb.Models;
using HotelWeb.Models.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWeb.Data.Repositories
{
    public class ApartmentRepository : BaseRepository<Apartment>, IApartmentRepository
    {
        private readonly HotelDbContext _context;

        public ApartmentRepository(HotelDbContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<List<Apartment>> GetAllApartmentsWithTypes()
        {
            return await _context.Apartments
                .Include(x => x.ApartmentTypes)
                .Select(x => new Apartment
                {
                    Id = x.Id,
                    Number = x.Number,
                    Capacity = x.Capacity,
                    Status = x.Status,
                    ApartmentTypes = new ApartmentType
                    {
                        Id = x.ApartmentTypes.Id,
                        Name = x.ApartmentTypes.Name,
                        Price = x.ApartmentTypes.Price
                    }
                })
                .ToListAsync();
        }

        public async Task<Apartment> GetApartmentWithTypeById(int id)
        {
            return await _context.Apartments.Include(x => x.ApartmentTypes).Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public Task<List<ReservationRequest>> GetAllReservations()
        {
            return _context.UserVisitors
                .Include(x => x.User)
                .Include(x => x.Visitor)
                .Select(x => new ReservationRequest
                {
                    UserName = x.User.Name,
                    UserSurname = x.User.Surname,
                    UserPatronymic = x.User.Patronymic,
                    UserLogin = x.User.Login,
                    UserRole = x.User.Role.Name,
                    CheckIn = x.Visitor.CheckIn,
                    CheckOut = x.Visitor.CheckOut,
                    ApartmentNumber = x.Visitor.Apartment.Number,
                    ApartmentCapacity = x.Visitor.Apartment.Capacity,
                    ApartmentStatus = x.Visitor.Apartment.Status,
                    ApartmentType = x.Visitor.Apartment.ApartmentTypes.Name
                })
                .ToListAsync();
        }

        public void ReservationApartment(ReservationRequest request)
        {
            var user = _context.Users.FirstOrDefaultAsync(x => x.Login == request.UserLogin).Result;
            var apartment = _context.Apartments.FirstOrDefaultAsync(x => x.Number == request.ApartmentNumber).Result;
        }
    }
}
