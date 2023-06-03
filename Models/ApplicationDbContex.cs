using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ultragamma.Models
{
    public class ApplicationDbContex : DbContext
    {
        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> opciones) : base(opciones)
        {

        }
        //Escribir los modelos
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<OrdenCompra> OrdenCompra { get; set; }
        public DbSet<DetalleOrden> DetalleOrden { get; set; }
        public DbSet<ImagenesProductos> imagenesProductos { get; set; }

    }
}
