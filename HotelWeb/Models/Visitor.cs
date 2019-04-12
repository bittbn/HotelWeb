using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWeb.Models
{
    public class Visitor
    {
        [Key]
        public int Id { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime CheckOut { get; set; }

        public int? ApartmentId { get; set; }
        public Apartment Apartment { get; set; }

        public List<UserVisitor> UserVisitors { get; set; }
    }
}
