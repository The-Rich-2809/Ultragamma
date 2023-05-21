using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Ultragamma.Models;

namespace Ultragamma.Controllers;

public class HomeController : Controller
{
    public readonly ApplicationDbContex _contexto;
    public HomeController(ApplicationDbContex contexto)
    {
        _contexto = contexto;
    }
    public IActionResult Index()
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
                }
            }
        }
        return View();
    }

    [HttpGet]
    public IActionResult IniciarSesion()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult IniciarSesion(string Correo, string Contrasena)
    {
        RegistroModel registro = new RegistroModel(_contexto);

        RegistroModel.Correo = Correo;
        RegistroModel.Contrasena = Contrasena;

        if (registro.IniciarSesion())
        {
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(365);
            options.IsEssential = true;
            options.Path = "/";
            HttpContext.Response.Cookies.Append("MiCookie", Correo, options);

            return RedirectToAction("Index");
        }
        else
        {
            ViewBag.Mensaje = "Correo y/o Contraseña Incorrecto";
            return View();
        }
    }

    [HttpGet]
    public IActionResult Registrate()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Registrate(Usuario usuario, string Contrasena, string Contrasena2)
    {
        if(Contrasena == Contrasena2)
        {
            int i = 0;
            List<Usuario> listaUsuarios = _contexto.Usuario.ToList();
            foreach (var user in listaUsuarios)
            {
                if (usuario.Correo == user.Correo)
                {
                    break;
                }
                else
                {
                    i++;
                }
            }
            if (i == listaUsuarios.Count)
            {
                RegistroModel registro = new RegistroModel(_contexto);
                usuario.Nivel = "Cliente";
                usuario.DireccionImagePerfil = "../Images/Usuarios/usuario.png";
                registro.Registrate(usuario);
                IniciarSesion(usuario.Correo, usuario.Contrasena);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.Mensaje = "Este correo ya esta registrado";
                return View();
            }
        }
        else
        {
            ViewBag.Mensaje = "Las contraseñas no son iguales";
            return View();
        }
        
    }
    public RedirectToActionResult CerrarSesion()
    {
        HttpContext.Response.Cookies.Delete("MiCookie");
        return RedirectToAction("Index");
    }
}
