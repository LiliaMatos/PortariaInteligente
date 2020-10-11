using System.ComponentModel.DataAnnotations;

namespace PortariaInteligente.Models
{
    public class Documento
    {
        [Key]
        public int DocumentoID { get; set; }

        [Required]
        [Display(Name = "Tipo de Documento")]
        public string DocumentoNome { get; set; }
    }
}
