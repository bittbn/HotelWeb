using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWeb.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Surname { get; set; }
        [Required, MaxLength(50)]
        public string Patronymic { get; set; }
        [Required, MaxLength(50)]
        public string Login { get; set; }
        [Required, DataType(DataType.Password)]
        public Guid Password { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }

        public List<UserVisitor> UserVisitors { get; set; }
    }
}
