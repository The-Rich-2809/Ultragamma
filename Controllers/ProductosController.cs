using Microsoft.AspNetCore.Mvc;
using Ultragamma.Models;

namespace Ultragamma.Controllers
{
    public class ProductosController : Controller
    {
        public readonly ApplicationDbContex _contexto;
        public ProductosController(ApplicationDbContex contexto)
        {
            _contexto = contexto;
        }

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
                    }
                }
            }
        }
        public IActionResult Hombres()
        {
            Cookies();
            return View();
        }
        public IActionResult Mujeres()
        {
            Cookies();
            return View();
        }
        public IActionResult Accesorios()
        {
            Cookies();
            return View();
        }
        public IActionResult Productos()
        {
            Cookies();
            ViewBag.image = "login.jpg";
            return View();
        }
        public IActionResult Carrito()
        {
            Cookies();
            return View();
        }
    }
}
