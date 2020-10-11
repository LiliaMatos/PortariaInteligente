using System.ComponentModel.DataAnnotations;

namespace PortariaInteligente.Models
{
    public class Usuario
    {
       [Key]
       public int UsuarioID{ get; set; }

       [Required, Display(Name = "Telefone Fixo")]
       public string UsuarioTelFixo { get; set; }


       [Required]
       [Display(Name = "Nome")]
       [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
       [StringLength(150, MinimumLength = 5)]
       public string UsuarioNome { get; set; }

       [Required(ErrorMessage = "O campo {0} é obrigatório")]
       [Display(Name = "E-mail")]
       [DataType(DataType.EmailAddress)]
       [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
       public string UsuarioEmail { get; set; }

       [Required]
       [Display(Name = "Celular")]
       [DataType(DataType.PhoneNumber)]
       public string UsuarioCel { get; set; }

       [Required]
       [Display(Name = "Fixo")]
       [DataType(DataType.PhoneNumber)]
       public string UsuarioFixo { get; set; }
        
        public Papel Papeis { get; set; }
    }
}
