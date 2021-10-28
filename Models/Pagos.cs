using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inmobiliaria.Models
{
    public class Pagos
    {
        [Key]
        [Display(Name = "Código Pago")]
        public int IdPago { get; set; }
        public int NumPago { get; set; }
        public int IdContr { get; set; }
        [ForeignKey("IdContr")]
        public Contratos Contratos { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Pago")]
        public DateTime FechaPago { get; set; }
        public decimal Importe { get; set; }
    }
}
