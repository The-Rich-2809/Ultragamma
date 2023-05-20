using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using Ultragamma.Models;

namespace Ultragamma.Controllers
{
    public class AdminController : Controller
    {
        public readonly ApplicationDbContex _contexto;
        public AdminController(ApplicationDbContex contexto)
        {
            _contexto = contexto;
        }
        //Verificar Cookies
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
            else
            {
                ViewBag.Entrar = "No";
            }
        }

        //Vista de Inicio del Admin
        public IActionResult Inicio()
        {
            Cookies();
            return View();
        }

        //Vista del Almacen
        public IActionResult Almacen()
        {
            List<Producto> listaProductos = _contexto.Producto.ToList();
            Cookies();
            return View(listaProductos);
        }
        [HttpGet]
        public IActionResult NuevoProducto()
        {
            Cookies();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NuevoProducto(Producto producto)
        {
            var productos = new ProductosModel(_contexto);
            productos.NuevoProducto(producto);
            Cookies();
            return RedirectToAction(nameof(Almacen));
        }
        [HttpGet]
        public IActionResult EditarProducto(int id)
        {
            var Producto = _contexto.Producto.FirstOrDefault(c => c.Id == id);
            Cookies();
            return View(Producto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarProducto(Producto producto)
        {
            var productos = new ProductosModel(_contexto);
            productos.EditarProducto(producto);
            Cookies();
            return RedirectToAction(nameof(Almacen));
        }
        [HttpGet]
        public IActionResult EliminarProducto(int? id)
        {
            var Producto = _contexto.Producto.FirstOrDefault(c => c.Id == id);
            Cookies();
            return View(Producto);
        }
        [HttpPost]
        public IActionResult EliminarProducto(int id)
        {
            var Producto = _contexto.Producto.FirstOrDefault(c => c.Id == id);
            _contexto.Producto.Remove(Producto);
            _contexto.SaveChanges();
            Cookies();
            return RedirectToAction(nameof(Almacen));
        }

        //Vista de Usuario
        public IActionResult Usuarios()
        {
            List<Usuario> listaUsuarios = _contexto.Usuario.ToList();
            Cookies();
            return View(listaUsuarios);
        }
        [HttpGet]
        public IActionResult EditarUsuarios(string id)
        {
            var Usuario = _contexto.Usuario.FirstOrDefault(c => c.Correo == id);
            Cookies();
            return View(Usuario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarUsuarios(Usuario usuario)
        {
            var usuarios = new RegistroModel(_contexto);
            usuarios.EditarUsuario(usuario);
            Cookies();
            return RedirectToAction(nameof(Usuarios));
        }
        [HttpGet]
        public IActionResult EliminarUsuario(string? id)
        {
            var Usuario = _contexto.Usuario.FirstOrDefault(c => c.Correo == id);
            Cookies();
            return View(Usuario);
        }
        [HttpPost]
        public IActionResult EliminarUsuario(string id, string Correo)
        {
            var Usuario = _contexto.Usuario.FirstOrDefault(c => c.Correo == id);
            _contexto.Usuario.Remove(Usuario);
            _contexto.SaveChanges();
            Cookies();
            return RedirectToAction(nameof(Usuarios));
        }

        //Vista de Compras
        public IActionResult Compras()
        {
            Cookies();
            return View();
        }

        //Vista de Ventas
        public IActionResult VentasTerminadas()
        {
            Cookies();
            return View();
        }
    }
}
