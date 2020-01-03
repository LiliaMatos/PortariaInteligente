using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortariaInteligente.Models
{
    public class TipoDocto
    {
        public int tipoDoctoId { get; set; }

        [Display(Name = "Tipo do documento")]
        [Required]
        public string  nomeDocto { get; set; }


        public List<TipoDocto> ListaDoctos()
        {
            return new List<TipoDocto>
            {
                new TipoDocto { tipoDoctoId = 1, nomeDocto = "RG_Lista"},
                new TipoDocto { tipoDoctoId = 2, nomeDocto = "CNH_Lista"},
                new TipoDocto { tipoDoctoId = 3, nomeDocto = "Passaporte_Lista"}
            };
        }

    }
}
