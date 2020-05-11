using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortariaInteligente.Models
{
    public class Document
    {
        public int IdDocument { get; set; }

        [Required, Display(Name = "Tipo de Documento")]
        public string NameDocument { get; set; }
    }
}
