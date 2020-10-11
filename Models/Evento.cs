using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortariaInteligente.Models
{
    public class Evento
    {
        [Key]
        public int EventoID{ get; set; }   

        [Required, Display(Name = "Nome do Evento")]
        public string EventoNome { get; set; }

        [Required, Display(Name = "Data do Evento"), DataType(DataType.Date)]
         public DateTime  EventoData { get; set; }

        [Required, Display(Name = "Hora do Evento"), DataType(DataType.Time)]
         public DateTime EventoHora { get; set; }

        [Required, Display(Name = "Local do Evento")]
        public string EventoLocal { get; set; }

        public Visitado Visitados { get; set; }
        public List<Convite> Convites { get; set; }



    }
}
