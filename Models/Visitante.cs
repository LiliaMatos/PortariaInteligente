using System.ComponentModel.DataAnnotations;

namespace PortariaInteligente.Models
{
    public class Visitante: Usuario
    {
   
        public int VisitanteID{ get; set; }

        [Required, Display(Name = "Número do documento")]
        public string DocumentoNumero { get; set; }

        [Display(Name = "Marca do carro")]
        public string CarroMarca { get; set; }

        [Display(Name = "Modelo")]
        public string CarroModelo { get; set; }

        [Display(Name = "Cor")]
        public string CarroCor { get; set; }

        [Display(Name = "Placa do carro")]
        public string CarroPlaca{ get; set; }

        public Documento Documentos { get; set; }
        public Empresa Empresas { get; set; }
    }
}
