using Microsoft.AspNetCore.Mvc;
using Ultragamma.Models;

namespace Ultragamma.Controllers
{
    public class ComprasController : Controller
    {
        public readonly ApplicationDbContex _contexto;
        public ComprasController(ApplicationDbContex contexto)
        {
            _contexto = contexto;
        }
        public static string Correo { get; set; } = string.Empty;
        public void Cookies()
        {
            var miCookie = HttpContext.Request.Cookies["MiCookie"];

            if (miCookie != null)
            {
                List<Usuario> listaUsuarios = _contexto.Usuario.ToList();
                foreach (var user in listaUsuarios)
                {
                    if (miCookie == user.Correo)
                    {
                        ViewBag.Nombre = user.Nombre;
                        ViewBag.Nivel = user.Nivel;
                        ViewBag.FotoPerfil = user.DireccionImagePerfil;
                        Correo = user.Correo;
                        ViewBag.Correo = user.Correo;
                        break;
                    }
                }
            }
            else
            {
                ViewBag.Entrar = "No";
            }
        }
        public IActionResult Direcciones(int id)
        {
            List<Direccion> listaDireccion = _contexto.Direccion.ToList();
            Cookies();
            return View(listaDireccion);
        }
        [HttpGet]
        public IActionResult AgregarDireccion()
        {
            Cookies();
            return View();
        }
        [HttpPost]
        public IActionResult AgregarDireccion(Direccion direccion)
        {
            Cookies();
            direccion.Correo = Correo;
            _contexto.Direccion.Add(direccion);
            _contexto.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult EliminarDireccion(string IdDireccion)
        {
            return View();
        }
    }
}
