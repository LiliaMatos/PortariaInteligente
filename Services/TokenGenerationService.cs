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
        public Visitado Authenticate(string username, string password)
        {
          
           
           var user = _context.Visitados.Where(x => x.nomeVisitado == username && 
            x.senhaVisitado == password).FirstOrDefault();

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("JWT:key");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.nomeVisitado),
                    new Claim("Portaria", user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.tokenVisitado = tokenHandler.WriteToken(token);

            user.senhaVisitado = null;

            return user;
        }
    }
}
