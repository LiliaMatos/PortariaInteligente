using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortariaInteligente.Models
{
    public class Visitado: Usuario

    {

        public int VisitadoID{ get; set; }  
        public List<Evento> Eventos { get; set; }

    }
}
