using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortariaInteligente.Models
{
    public class Documento
    {
        public int DocumentoId { get; set; }

        [Display(Name = "Tipo de Documento")]
        [Required]
        public string nomeDocumento { get; set; }
    }
}
