using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortariaInteligente.Models 
{
    public class Anfitriao
    {
        public int AnfitriaoId{ get; set; }

        [Display(Name = "Nome")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(150, MinimumLength = 5)]
        [Required]
        public string nomeAnfitriao { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string emailAnfitriao { get; set; }

        [Display(Name = "Celular")]
        [DataType(DataType.PhoneNumber)]
        public string celAnfitriao { get; set; }

        [Display(Name = "Fixo")]
        [Required]
        public string  fixoAnfitriao { get; set; }

        [Display(Name = "Senha")]
        public string senhaAnfitriao { get; set; }

        [Display(Name = "Token")]
        public string tokenAnfitiao { get; set; }
    }
}
