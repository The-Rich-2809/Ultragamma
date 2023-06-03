namespace Ultragamma.Models
{
    public class Direccion
    {
        public int Id { get; set; }
        public string Correo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Calle { get; set; } = string.Empty;
        public string NumExt { get; set; } = string.Empty;
        public string NumInt { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Alcaldia { get; set; } = string.Empty;
        public string Colonia { get; set; } = string.Empty;
        public string CP { get; set; } = string.Empty;
        public bool Check { get; set; }
        public class DireccionList
        {
            public List<Direccion> Direccion { get; set; }

        }

    }
}
