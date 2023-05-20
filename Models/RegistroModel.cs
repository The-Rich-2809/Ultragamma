using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Ultragamma.Models
{
    public class RegistroModel
    {
        public readonly ApplicationDbContex _contexto;
        public RegistroModel(ApplicationDbContex contexto)
        {
            _contexto = contexto;
        }

        public static string Correo { get; set; } = string.Empty;
        public static string Contrasena { get; set; } = string.Empty;
        public static string Nombre { get; set; } = string.Empty;
        public static int Nivel { get; set; }

        public bool IniciarSesion()
        {
            List<Usuario> listaUsuarios = _contexto.Usuario.ToList();

            foreach (var user in listaUsuarios)
            {
                if (Correo == user.Correo)
                {
                    if (Contrasena == user.Contrasena)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void Registrate(Usuario usuario)
        {
            _contexto.Usuario.Add(usuario);
            _contexto.SaveChanges();
        }
        public void EditarUsuario(Usuario usuario)
        {
            _contexto.Usuario.Update(usuario);
            _contexto.SaveChanges();
        }
    }
}
