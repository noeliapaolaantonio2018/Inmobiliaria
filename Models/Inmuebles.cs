namespace Inmobiliaria.Models
{
    public class Inmuebles
    {
        public int IdInm { get; set; }
        public int IdProp { get; set; }
        public Propietarios Propietarios { get; set; }
        public string Direccion { get; set; }
        public string Tipo { get; set; }
        public string Uso { get; set; }
        public int CantAmbientes { get; set; }
        public decimal Costo { get; set; }
        public bool Disponible { get; set; }
    }
}
