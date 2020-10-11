using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortariaInteligente.Models
{
    public class Convite
    {
        [Key]
        public int ConviteID { get; set; }
        public Visitante Visitantes { get; set; }
        public List<Visitado> Visitados { get; set; }
    }
}

