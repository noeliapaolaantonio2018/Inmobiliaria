using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inmobiliaria.Models
{
    public class Usuarios
    {
        [Key]
        public int IdUs { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }
        public string Avatar { get; set; }
        [NotMapped]
        public IFormFile AvatarFile { get; set; }


    }
}
