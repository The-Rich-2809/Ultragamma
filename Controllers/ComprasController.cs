using Microsoft.AspNetCore.Mvc;
using Ultragamma.Models;

namespace Ultragamma.Controllers
{
    public class ComprasController : Controller
    {
        public IActionResult Direcciones()
        {
            ViewBag.Header = RegistrosModel.Header();
            return View();
        }
    }
}
