using Microsoft.AspNetCore.Mvc;
using PayPal.Api;
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
                    }
                }
            }
        }
        public IActionResult Hombres()
        {
            List<Producto> listaProductos = _contexto.Producto.ToList();
            ViewBag.Images = _contexto.imagenesProductos.ToList();
            Cookies();
            return View(listaProductos);
        }
        public IActionResult Mujeres()
        {
            List<Producto> listaProductos = _contexto.Producto.ToList();
            ViewBag.Images = _contexto.imagenesProductos.ToList();
            Cookies();
            return View(listaProductos);
        }
        public IActionResult Accesorios()
        {
            List<Producto> listaProductos = _contexto.Producto.ToList();
            ViewBag.Images = _contexto.imagenesProductos.ToList();
            Cookies();
            return View(listaProductos);
        }
        [HttpGet]
        public IActionResult Productos(int? id)
        {
            var Producto = _contexto.Producto.FirstOrDefault(c => c.Id == id);
            ViewBag.Images = _contexto.imagenesProductos.ToList();
            ViewBag.ProductoId = id; 
            Cookies();
            return View(Producto);
        }
        [HttpPost]
        public IActionResult Productos(int id, Carrito carrito)
        {
            carrito.ProductoId = id;
            int t = 0;
            Cookies();
            List<Carrito> listaCarrito = _contexto.Carrito.ToList();
            foreach (var item in listaCarrito)
            {
                if (carrito.ProductoId == item.ProductoId)
                {
                    carrito.Cantidad = item.Cantidad + carrito.Cantidad;
                    _contexto.Carrito.Remove(item);
                    _contexto.SaveChanges();
                    break;
                }
                t++;
            }
            if (listaCarrito.Count == t)
            {
                carrito.Precio = carrito.Precio * carrito.Cantidad;
                carrito.ProductoId = id;
                carrito.Correo = Correo;
                _contexto.Carrito.Add(carrito);
                _contexto.SaveChanges();
            }
            else
            {
                carrito.Id = 0;
                carrito.Precio = carrito.Precio * carrito.Cantidad;
                carrito.Correo = Correo;
                _contexto.Carrito.Add(carrito);
                _contexto.SaveChanges();
            }

            return RedirectToAction(nameof(Carrito));
        }
        [HttpGet]
        public IActionResult Carrito()
        {
            List<Carrito> listaCarrito = _contexto.Carrito.ToList();
            ViewBag.Images = _contexto.imagenesProductos.ToList();
            ViewBag.Productos = _contexto.Producto.ToList();
            Cookies();
            return View(listaCarrito);
        }
    }
}
