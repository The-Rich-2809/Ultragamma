using Microsoft.AspNetCore.Mvc;

namespace Ultragamma.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult IniciarSesion()
        {
            return View();
        }
        public IActionResult Registrate()
        {
            return View();
        }
    }
}
