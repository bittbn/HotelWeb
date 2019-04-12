using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWeb.Models
{
    public class UserVisitor
    {
        [Key]
        public int Id { get; set; }

        public int? UserId { get; set; }
        public int? VisitorId { get; set; }
        public User User { get; set; }
        public Visitor Visitor { get; set; }
    }
}
