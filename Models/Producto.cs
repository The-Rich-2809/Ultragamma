using System.ComponentModel.DataAnnotations;

namespace Ultragamma.Models
{
    public class Producto
    {
        [Key][Required]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        public string Descripcion { get; set; } = string.Empty;
        [Required]
        public string Categoria { get; set; } = string.Empty;
        [Required]
        public string Sexo { get; set; } = string.Empty;
        [Required]
        public string Talla { get; set;} = string.Empty;
        [Required]
        public string Color { get; set; } = string.Empty;
        [Required]
        public string Precio { get; set; } = string.Empty;
        [Required]
        public string Existencia { get; set; } = string.Empty;
    }
}
