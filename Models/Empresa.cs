using System.ComponentModel.DataAnnotations;

namespace PortariaInteligente.Models
{
    public class Empresa
    {
        [Key]
        public int EmpresaID { get; set; }
              
        [Required]
        [Display(Name = "Nome da Empresa")]
        public string EmpresaNome { get; set; }
    }
}
