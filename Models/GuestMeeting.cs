using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortariaInteligente.Models
{
    public class GuestMeeting
    {
        [Key]
        public int IdGuestMeeting { get; set; }
        public int IdMeeting { get; set; }
        [ForeignKey("IdMeeting")]
        public Meeting Meeting { get; set; }
        public int IdExternalUser { get; set; }
        [ForeignKey("IdExternalUser")]
        public ExternalUser ExternalUser { get; set; }
    }
}

