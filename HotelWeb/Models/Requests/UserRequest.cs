using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWeb.Models.Requests
{
    public class UserRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname{ get; set; }
        public string Patronymic { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
