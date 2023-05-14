using Microsoft.AspNetCore.Mvc;
using Ultragamma.Models;

namespace Ultragamma.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Hombres()
        {
            ViewBag.Header = RegistrosModel.Header();
            return View();
        }
        public IActionResult Mujeres()
        {
            ViewBag.Header = RegistrosModel.Header();
            return View();
        }
        public IActionResult Accesorios()
        {
            ViewBag.Header = RegistrosModel.Header();
            return View();
        }
        public IActionResult Productos()
        {
            ViewBag.Header = RegistrosModel.Header();
            ViewBag.image = "login.jpg";
            return View();
        }
        public IActionResult Carrito()
        {
            ViewBag.Header = RegistrosModel.Header();
            return View();
        }
    }
}
