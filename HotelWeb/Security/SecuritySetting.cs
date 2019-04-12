using HotelWeb.Models.Requests;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HotelWeb.Security
{
    public class SecuritySetting
    {
        public string SecretKey { get; set; }
        public Guid GetHash(string password)
        {
            using (var hash = MD5.Create())
            {
                return new Guid(string.Concat(hash.ComputeHash(Encoding.Unicode.GetBytes(password)).Select(x => x.ToString("x2"))));
            }
        }

        public string GetToken(UserRequest request)
        {
            var key = Encoding.ASCII.GetBytes(SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, request.Login),
                    new Claim(ClaimTypes.Role, request.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
