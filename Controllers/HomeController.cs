using Microsoft.AspNetCore.Mvc;
using Ultragamma.Models;

namespace Ultragamma.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Header = RegistrosModel.Header();
            return View();
        }

        [HttpGet]
        public IActionResult IniciarSesion()
        {
            ViewBag.Mensaje = RegistrosModel.Mensaje;
            return View();
        }
        [HttpPost]
        public RedirectToActionResult IniciarSesion(string Correo, string Contrasena)
        {
            RegistrosModel._Correo = Correo;
            RegistrosModel._Contrasena = Contrasena;
            if (RegistrosModel.IniciarSesion() == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("IniciarSesion");
            }
        }

        [HttpGet]
        public IActionResult Registrate()
        {
            ViewBag.Mensaje = RegistrosModel.Mensaje;
            RegistrosModel.Mensaje = String.Empty;
            return View();
        }
        [HttpPost]
        public RedirectToActionResult Registrate(string Nombre, string Correo, string Contrasena)
        {
            RegistrosModel._Nombre = Nombre;
            RegistrosModel._Correo = Correo;
            RegistrosModel._Contrasena = Contrasena;
            if(RegistrosModel.NuevoUsuario() == true)
            {
                RegistrosModel.IniciarSesion();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public RedirectToActionResult CerrarSesion()
        {
            RegistrosModel.CerrarSesion();
            return RedirectToAction("Index");
        }
    }
}
