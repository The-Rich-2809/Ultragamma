namespace Ultragamma.Models
{
    public class Carrito
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public string Correo { get; set; }
        public int Cantidad { get; set; }
    }
}
