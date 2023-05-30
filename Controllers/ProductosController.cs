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
                        ViewBag.FotoPerfil = user.DireccionImagePerfil;
                    }
                }
            }
        }
        public IActionResult Hombres()
        {
            List<Producto> listaProductos = _contexto.Producto.ToList();
            Cookies();
            return View(listaProductos);
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
        public IActionResult Productos(int id)
        {
            var Producto = _contexto.Producto.FirstOrDefault(c => c.Id == id);
            Cookies();
            ViewBag.image = "login.jpg";
            return View(Producto);
        }
        public IActionResult Carrito()
        {
            Cookies();
            return View();
        }
    }
}
