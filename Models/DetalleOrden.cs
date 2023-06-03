namespace Ultragamma.Models
{
    public class DetalleOrden
    {
        public int Id { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public string Correo { get; set; }
    }
}
