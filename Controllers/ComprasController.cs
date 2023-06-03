using Microsoft.AspNetCore.Mvc;
using Ultragamma.Models;
using PayPal.Api;
using static Ultragamma.Models.Direccion;

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
        public static int DireccionId { get; set; }
        public static int TarjetaId { get; set; }
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
        [HttpGet]
        public IActionResult Direcciones()
        {
            List<Direccion> listaDireccion = _contexto.Direccion.ToList();
            ViewBag.Images = _contexto.imagenesProductos.ToList();
            ViewBag.Productos = _contexto.Producto.ToList();
            ViewBag.Carrito = _contexto.Carrito.ToList();
            Cookies();
            return View(listaDireccion);
        }
        [HttpPost]
        public IActionResult Submit(List<Direccion> model, List<int> Id)
        {
            for (var i = 0; i < model.Count; i++)
            {
                if (model[i].Check == true)
                {
                    DireccionId = Id[i];
                    i = model.Count;
                }
            }
            return RedirectToAction(nameof(Confirmar));
        }
        public IActionResult Confirmar()
        {
            int Total = 0;
            Cookies();
            List<Carrito> listaCarrito = _contexto.Carrito.ToList();
            foreach(var carrito in listaCarrito)
            {
                if (carrito.Correo == Correo)
                {
                    Total = carrito.Precio + Total;
                }
            }
            ViewBag.Total = Total;

            return View();
        }
        public IActionResult CompraRealizada(OrdenCompra ordenCompra, DetalleOrden detalleOrden)
        {
            Cookies();
            int OCID = 0;
            ordenCompra.DireccionId = DireccionId;
            ordenCompra.Correo = Correo;
            ordenCompra.Estado = "Prerando tu paquete";

            List<Carrito> listaCarrito = _contexto.Carrito.ToList();
            foreach(var carrito in listaCarrito)
            {
                if(carrito.Correo == Correo)
                {
                    ordenCompra.Total = ordenCompra.Total + carrito.Precio;
                }
            }
            _contexto.OrdenCompra.Add(ordenCompra);
            _contexto.SaveChanges();

            int t = 0;
            List<OrdenCompra> listaordenCompra = _contexto.OrdenCompra.ToList();
            foreach(var oc in listaordenCompra)
            {
                if(oc.Correo == Correo)
                { t++; }
            }
            int y = 0;
            foreach (var oc in listaordenCompra)
            {
                if (oc.Correo == Correo)
                {
                    y++;
                    if(y == t)
                    {
                        OCID = oc.Id; break;
                    }
                }
            }

            foreach (var carrito in listaCarrito)
            {
                if (carrito.Correo == Correo)
                {
                    detalleOrden.OrdenId = OCID;
                    detalleOrden.ProductoId = carrito.ProductoId;
                    detalleOrden.Cantidad = carrito.Cantidad;
                    detalleOrden.Precio = carrito.Precio;
                    detalleOrden.Correo = Correo;
                    detalleOrden.Id = 0;
                    _contexto.DetalleOrden.Add(detalleOrden);
                    _contexto.Carrito.Remove(carrito);
                    _contexto.SaveChanges();
                }
            }

            return View();
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
            direccion.Check = false;
            _contexto.Direccion.Add(direccion);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Direcciones));
        }
        [HttpGet]
        public IActionResult EliminarDireccion(string IdDireccion)
        {
            return View();
        }
    }
}
