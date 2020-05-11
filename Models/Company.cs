using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortariaInteligente.Models
{
    public class Company
    {
        [Key]
        public int IdCompany { get; set; }

        [Display(Name = "Nome da Empresa")]
        [Required]
        public string NameCompany { get; set; }
    }
}
