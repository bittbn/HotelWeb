using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWeb.Models.Requests
{
    public class ReservationRequest
    {
        public string UserName { get; set; }
        public string UserSurname{ get; set; }
        public string UserPatronymic{ get; set; }
        public string UserLogin{ get; set; }
        public string UserRole{ get; set; }
        public DateTime CheckIn{ get; set; }
        public DateTime CheckOut { get; set; }
        public int ApartmentNumber { get; set; }
        public bool ApartmentStatus { get; set; }
        public int ApartmentCapacity { get; set; }
        public string ApartmentType { get; set; }
    }
}
