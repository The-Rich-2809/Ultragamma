using Microsoft.AspNetCore.Mvc;

namespace Ultragamma.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Hombres()
        {
            return View();
        }
        public IActionResult Mujeres()
        {
            return View();
        }
        public IActionResult Accesorios()
        {
            return View();
        }
        public IActionResult Productos()
        {
            return View();
        }
    }
}
