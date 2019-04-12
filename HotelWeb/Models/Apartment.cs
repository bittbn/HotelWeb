using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWeb.Models
{
    public class Apartment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public bool Status { get; set; } = false;

        public int? ApartmentTypeId { get; set; }
        public ApartmentType ApartmentTypes { get; set; }

        public List<Visitor> Visitors { get; set; }
    }
}