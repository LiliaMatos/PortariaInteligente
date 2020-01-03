using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortariaInteligente.Models
{
    public class Carro
    {
        public int CarroId { get; set; }
        [Display(Name = "Placa")]
        [StringLength(7)]
        public string placaCarro { get; set; }
        [Display(Name = "Marca")]
        public string marcaCarro { get; set; }
        [Display(Name = "Modelo")]
        public string modeloCarro { get; set; }
        [Display(Name = "Cor")]
        public string corCarro { get; set; }   


    }
}
