using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PortariaInteligente.Data;
using PortariaInteligente.Models;
using System.Web.Providers.Entities;

namespace PortariaInteligente.Services
{
    public class TokenGenerationService
    {
        private readonly PortariaInteligenteContext _context;

        public TokenGenerationService(PortariaInteligenteContext context)
        {
            _context = context;
        }
        public ApplicationUser Authenticate(string username, string password)
        {
          
           
           var user = _context.ApplicationUsers.Where(x => x.UserName == username && 
            x.PasswordHash  == password).FirstOrDefault();

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("JWT:key");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName ),
                    new Claim("Portaria", user.JWTRole)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.JWTToken = tokenHandler.WriteToken(token);

            user.PasswordHash  = null;

            return user;
        }
    }
}
