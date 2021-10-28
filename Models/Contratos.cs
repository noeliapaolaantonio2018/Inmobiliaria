using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inmobiliaria.Models
{
    public class Contratos
    {
        [Key]
        [Display(Name = "Código Contrato")]
        public int IdContr { get; set; }
        public int IdInq { get; set; }
        [ForeignKey("IdInq")]
        public Inquilinos Inquilinos { get; set; }
        public int IdInm { get; set; }
        [ForeignKey("IdInm")]
        public Inmuebles Inmuebles { get; set; }

        [Display(Name = "FechaInicio")]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "FechaCierre")]
        public DateTime FechaCierre { get; set; }

        [Display(Name = "$ Monto")]
        public decimal Monto { get; set; }
        public bool Vigente { get; set; }
    }
}
