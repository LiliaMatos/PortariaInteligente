using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PortariaInteligente.Models 
{
    public class InternalUser: ApplicationUser

    {
        [Key]
        public int IdInternalUser { get; set; }
        [Required]
       /* public int IdApplicationUser { get; set; }
        [ForeignKey("IdApplicationUser")]
        public ApplicationUser ApplictionUser { get; set; }*/
        public string IdSG { get; set; }

        /*[Required, Display(Name = "Nome"), RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), StringLength(150, MinimumLength = 5)
        public string nomeVisitado { get; set; }*/

        /*[Required(ErrorMessage = "O campo {0} é obrigatório"), Display(Name = "E-mail"), DataType(DataType.EmailAddress), EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string emailVisitado { get; set; }*/

        /*[Required, Display(Name = "Celular"), DataType(DataType.PhoneNumber)]
        public string celVisitado { get; set; }*/

        /*[Required, Display(Name = "Fixo"), DataType(DataType.PhoneNumber)]
        public string fixoVisitado { get; set; }*/

    }
}
