using System;

namespace Inmobiliaria.Models
{
    public class Contratos
    {
        public int IdContr { get; set; }
        public int IdInq { get; set; }
        public Inquilinos Inquilinos { get; set; }
        public int IdInm { get; set; }
        public Inmuebles Inmuebles { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaCierre { get; set; }
        public decimal Monto { get; set; }
        public bool Vigente { get; set; }
    }
}
