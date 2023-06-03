namespace Ultragamma.Models
{
    public class OrdenCompra
    {
        public int Id { get; set; }
        public int DireccionId { get; set; }
        public string Correo { get; set; }
        public int Total { get; set; }
        public string Estado { get; set; }

    }
}
