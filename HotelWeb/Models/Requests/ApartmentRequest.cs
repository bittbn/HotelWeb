using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWeb.Models.Requests
{
    public class ApartmentRequest
    {
        public int Number { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public string Type { get; set; }
    }
}
