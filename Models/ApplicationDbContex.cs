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

    }
}
