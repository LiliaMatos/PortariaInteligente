using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortariaInteligente.Models
{
    public class ExternalUser: ApplicationUser
    {
        [Key]
        public int IdExternalUser { get; set; }

        /*public int IdApplicationUser { get; set; }
        [ForeignKey("IdApplicationUser")]
        public ApplicationUser ApplicationUser { get; set; }*/

        [Required, Display(Name = "Empresa")]
        public int IdCompany { get; set; }
        [ForeignKey("IdCompany")]
        public Company Company{ get; set; }


        [Required, Display(Name = "Documento")]
        public int IdDocument { get; set; }
        [ForeignKey("IdDocument")]
        public Document Document { get; set; }

        [Required, Display(Name = "Número do documento")]
        public string NumberDoc { get; set; }

        [Display(Name = "Marca do carro")]
        public string BrandCar { get; set; }

        [Display(Name = "Modelo")]
        public string ModelCar { get; set; }

        [Display(Name = "Cor")]
        public string ColorCar { get; set; }

        [Display(Name = "Placa do carro")]
        public string PlateCar { get; set; }
    }
}
