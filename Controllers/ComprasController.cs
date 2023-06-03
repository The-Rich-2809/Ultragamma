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
            return RedirectToAction(nameof(Tarjetas));
        }
        public IActionResult Tarjetas()
        {
            List<Tarjeta> listaTarjetas = _contexto.Tarjeta.ToList();
            Cookies();
            return View(listaTarjetas);
        }
        [HttpPost]
        public IActionResult Submit1(List<Tarjeta> model, List<int> Id)
        {
            for (var i = 0; i < model.Count; i++)
            {
                if (model[i].Check == true)
                {
                    TarjetaId = Id[i];
                    i = model.Count;
                }
            }
            return RedirectToAction(nameof(Tarjetas));
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
