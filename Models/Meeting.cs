using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortariaInteligente.Models
{
    public class Meeting
    {
        [Key]
        public int IdMeeting{ get; set; }

        [Required, Display(Name = "Visitado")]
        public int IdInternalUser { get; set; }
        [ForeignKey("IdInternalUser")]
        public InternalUser InternalUser { get; set; }

        [Required, Display(Name = "Nome do Evento")]
        public string NameMeeting { get; set; }

        [Required, Display(Name = "Data do Evento"), DataType(DataType.Date)]
         public DateTime  DateMeeting { get; set; }

        [Required, Display(Name = "Hora do Evento"), DataType(DataType.Time)]
         public DateTime TimeMeeting { get; set; }

        [Required, Display(Name = "Local do Evento")]
        public string PlaceMeeting { get; set; }



    }
}
