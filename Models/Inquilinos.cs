using System.ComponentModel.DataAnnotations;

namespace Inmobiliaria.Models
{
    public class Inquilinos
    {
        [Key]
        [Display(Name = "Código Inquilino")]
        public int IdInq { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }

        public string Telefono { get; set; }

        [Display(Name = "Lugar de Trabajo")]
        public string DireccionTrabajo { get; set; }

        [Display(Name = "Nombre Garante")]
        public string Nombre_Garante { get; set; }

        [Display(Name = "Dni del Garante")]
        public string Dni_Garante { get; set; }

      
    }
}
