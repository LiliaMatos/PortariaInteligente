using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortariaInteligente.Models
{
    public class Evento
    {
        public int EventoId{ get; set; }

        [Display(Name = "Nome do Evento")]
        [Required]
        public string nomeEvento { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime  dataEvento { get; set; }

        [Display(Name = "Hora")]
        [DataType(DataType.Time)]
        public DateTime horaEvento { get; set; }

        [Display(Name = "Local")]
        [Required]
        public string localEvento { get; set; }

        [Display(Name = "Anfitrião/Responsável")]
        public int AnfitriaoId { get; set; }
        public Anfitriao anfitriao { get; set; }

    }
}
