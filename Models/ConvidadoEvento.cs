using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortariaInteligente.Models
{
    public class ConvidadoEvento
    {
        public int ConvidadoEventoId { get; set; }
        public int EventoId { get; set; }
        public Evento evento { get; set; }
        public int ConvidadoId { get; set; }
        public Convidado convidado { get; set; }
    }
}

