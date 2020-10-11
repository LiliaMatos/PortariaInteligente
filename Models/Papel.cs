using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortariaInteligente.Models
{
    public class Papel
    {
        [Key]
        public int PapelID { get; set; }

        [Required]
        [Display(Name = "Nome do Papel")]
        public string PapelNome { get; set; }

        public List<Usuario> Usuarios { get; set; }
    }
}
