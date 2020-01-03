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
        //Adicionar um campo tipo docto, onde vai constar os possíveis tipos de doctos
        public int tipoDoctoConvidadoId { get; set; }

        [Display(Name = "Tipo do documento com foto")]
        [Required]
        public TipoDocto  tipoDocto { get; set; }

        [Display(Name = "Número do documento")]
        [Required]
        public string  numeroDoctoConvidado { get; set; }
        public int carroId { get; set; }

        [Display(Name = "Carro")]
        public Carro carro { get; set; }
    }
}
