using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Ultragamma.Models
{
    public class Usuario
    {
        [Key][Required]
        public string Correo { get; set; } = string.Empty;
        [Required]
        public string Contrasena { get; set; } = string.Empty;
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        public string Nivel { get; set; } = string.Empty;
        public string DireccionImagePerfil { get; set; } = string.Empty;
    }
}