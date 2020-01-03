using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortariaInteligente.Models
{
    public class Convidado
    {
        public int ConvidadoId { get; set; }

        [Display(Name = "Nome"), Required ]
        public string nomeConvidado { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string emailConvidado { get; set; }

        [Display(Name = "Celular")]
        [DataType(DataType.PhoneNumber)]
        public string celConvidado { get; set; }

        [Display(Name = "Tipo do documento com foto")]
        [Required]
        public string  tipoDocto { get; set; }

        [Display(Name = "Número do documento")]
        [Required]
        public string  numeroDoctoConvidado { get; set; }

        [Display(Name = "Placa do carro")]
        public string placaCarro { get; set; }

        [Display(Name = "Marca")]
        public string marcaCarro { get; set; }

        [Display(Name = "Modelo")]
        public string modeloCarro { get; set; }

        [Display(Name = "Cor")]
        public string corCarro { get; set; }
    }
}
