using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ultragamma.Helpers;
using Ultragamma.Models;

namespace Ultragamma.Controllers
{
    public class UsuarioController : Controller
    {
        private HelperUploadFiles helperUpload;
        public readonly ApplicationDbContex _contexto;
        public UsuarioController(HelperUploadFiles helperUpload, ApplicationDbContex contexto)
        {
            _contexto = contexto;
            this.helperUpload = helperUpload;
        }
        //Verificar Cookies
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
                        break;
                    }
                }
            }
            else
            {
                ViewBag.Entrar = "No";
            }
        }
        public IActionResult Inicio()
        {
            Cookies();
            return View();
        }

        


        public IActionResult Direcciones()
        {
            List<Direccion> listaDireccion = _contexto.Direccion.ToList();
            Cookies();
            return View(listaDireccion);
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
        public IActionResult EditarDireccion(int id)
        {
            var Direccion = _contexto.Direccion.FirstOrDefault(c => c.Id == id);
            Cookies();
            return View(Direccion);
        }
        [HttpPost]
        public IActionResult EditarDireccion(Direccion direccion)
        {
            Cookies();
            _contexto.Update(direccion);
            _contexto.SaveChanges();
            return RedirectToAction(nameof(Direcciones));
        }
        [HttpGet]
        public IActionResult EliminarDireccion(int? id)
        {
            var Direccion = _contexto.Direccion.FirstOrDefault(c => c.Id == id);
            Cookies();
            return View(Direccion);
        }
        [HttpPost]
        public IActionResult EliminarDireccion(int id)
        {
            var Direccion = _contexto.Direccion.FirstOrDefault(c => c.Id == id);
            _contexto.Direccion.Remove(Direccion);
            _contexto.SaveChanges();
            Cookies();
            return RedirectToAction(nameof(Direcciones));
        }

    }
}
