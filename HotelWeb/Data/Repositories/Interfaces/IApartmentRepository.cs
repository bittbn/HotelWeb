using HotelWeb.Models;
using HotelWeb.Models.Requests;
using HotelWeb.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWeb.Data.Repositories.Interfaces
{
    public interface IApartmentRepository : IBaseRepository<Apartment>
    {
        Task<Apartment> GetApartmentWithTypeById(int id);
        Task<List<Apartment>> GetAllApartmentsWithTypes();
        Task<List<ReservationRequest>> GetAllReservations();
        void ReservationApartment(ReservationRequest request);
    }
}
