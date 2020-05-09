using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PortariaInteligente.Models 
{
    public class Visitado:IdentityUser
    {
        public int VisitadoId { get; set; }

        public int IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [Display(Name = "Nome")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(150, MinimumLength = 5)]
        [Required]
        public string nomeVisitado { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]       
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string emailVisitado { get; set; }

        [Display(Name = "Celular")]
        [DataType(DataType.PhoneNumber)]
        public string celVisitado { get; set; }

        [Display(Name = "Fixo")]
        [Required]
        public string fixoVisitado { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string senhaVisitado { get; set; }

        [Display(Name = "Confirma_Senha")]
        [Compare("Password", ErrorMessage = "As senhas não conferem.")]
        public string senhaVisitadoConfimacao { get; set; }

        [Display(Name = "Token")]
        public string tokenVisitado { get; set; }
        public string Role { get; set; }
     
    }
}
