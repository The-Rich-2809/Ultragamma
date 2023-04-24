using Microsoft.AspNetCore.Mvc;
using Ultragamma.Models;

namespace Ultragamma.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Almacen()
        {
            ViewBag.Header = RegistrosModel.Header();
            ViewBag.ProductosHombres = AlmacenModel.ProductosHombres();
            return View();
        }
        public IActionResult NuevoProducto()
        {
            ViewBag.Header = RegistrosModel.Header();
            return View();
        }
    }
}
