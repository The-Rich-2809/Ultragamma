namespace Ultragamma.Models
{
    public class Tarjeta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; } = string.Empty;
        public string NumTarjeta { get; set; } = string.Empty;
        public string FechaVen { get; set; } = string.Empty;
        public string CVV { get; set; } = string.Empty;
        public bool Check { get; set; } = false;

    }
}
