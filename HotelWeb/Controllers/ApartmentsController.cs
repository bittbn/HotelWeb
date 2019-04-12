using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelWeb.Data.Repositories.Interfaces;
using HotelWeb.Models;
using HotelWeb.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelWeb.Controllers
{
    [Authorize(Roles = "SuperAdmin, Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly IApartmentRepository _apartmentRepository;
        public ApartmentsController(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }

        // GET: api/Apartments
        [HttpGet()]
        public Task<List<Apartment>> Get()
        {
            return _apartmentRepository.GetAll();
        }
        
        // GET: api/Apartments/5
        [HttpGet("reservation")]
        public Task<List<ReservationRequest>> GetReservations()
        {
            return _apartmentRepository.GetAllReservations();
        }

        // POST: api/Apartments
        [HttpPost("reservation")]
        public void ReservationApartment([FromBody] ReservationRequest request)
        {

        }

        // PUT: api/Apartments/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Apartment apartmentNew)
        {
            if (apartmentNew == null)
                return BadRequest();

            var apartmentOld = _apartmentRepository.GetById(id).Result;

            if (apartmentOld == null)
                return NotFound();

            try
            {
                apartmentOld.Number = apartmentNew.Number;
                apartmentOld.Capacity = apartmentNew.Capacity;
                apartmentOld.Status = apartmentNew.Status;
                apartmentOld.ApartmentTypeId = apartmentNew.ApartmentTypeId;
                

                _apartmentRepository.Update(apartmentOld);
                _apartmentRepository.Save();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _apartmentRepository.Delete(_apartmentRepository.GetById(id).Result);
            _apartmentRepository.Save();
        }
    }
}
