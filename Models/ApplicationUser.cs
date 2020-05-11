using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortariaInteligente.Models
{
    public class ApplicationUser: IdentityUser 
    {
        [Key]
        public int IdApplicationUser { get; set; }

        public int IdIdentityUser { get; set; }
        [ForeignKey("IdIdentityUser")]
        public IdentityUser IdentityUser { get; set; }
        public int IdIdentityRole { get; set; }
        [ForeignKey("IdIdentityRole")]
        public IdentityRole IdentityRole { get; set; }

        [Required, Display(Name = "Telefone Fixo")]
        public string LandPhone { get; set; }

        [Required, Display(Name = "JWT Token")]
        public string JWTToken { get; set; }
        [Required, Display(Name = "JWT Role")]
        public string JWTRole { get; set; }
    }
}
