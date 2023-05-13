using Microsoft.AspNetCore.Mvc;
using Ultragamma.Models;

namespace Ultragamma.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Inicio()
        {
            ViewBag.Header = RegistrosModel.Header();
            return View();
        }
        public IActionResult Almacen()
        {
            ViewBag.Header = RegistrosModel.Header();
            ViewBag.ProductosHombres = AlmacenModel.ProductosHombres();
            return View();
        }
        public IActionResult Usuarios()
        {
            ViewBag.Header = RegistrosModel.Header();
            return View();
        }
        public IActionResult Compras()
        {
            ViewBag.Header = RegistrosModel.Header();
            return View();
        }
        public IActionResult VentasTerminadas()
        {
            ViewBag.Header = RegistrosModel.Header();
            return View();
        }
        [HttpGet]
        public IActionResult NuevoProducto()
        {
            ViewBag.Header = RegistrosModel.Header();
            return View();
        }
        [HttpPost]
        public IActionResult NuevoProducto(string Producto, string Categoria, string Precio,  string Imagenes, string Cantidad, string Descripcion)
        {
            AlmacenModel._Producto = Producto;
            AlmacenModel._Categoria = Categoria;
            AlmacenModel._Precio = Precio;
            AlmacenModel._Cantidad = Cantidad;
            AlmacenModel.NuevoProducto();
            ViewBag.Mensaje = AlmacenModel.Mensaje;
            ViewBag.Header = RegistrosModel.Header();
            return View();
        }
    }
}
