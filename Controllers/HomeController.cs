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
        Initialize();
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
    public void Initialize()
    {

        _contexto.Database.EnsureCreated();
        if (_contexto.Usuario.Any())
        {
            // En el caso de que ya tenga datos dentro de la tabla carrera finalizamos la función.
            return;
        }
        var insertarUsuarios = new Usuario[]
        {
            new Usuario{Nombre="Rich", Correo="ricardo_138@outlook.com", Contrasena="1234", Nivel="Admin", DireccionImagePerfil="../Images/Usuarios/ricardo_138@outlook.comgato.jpg"},
            new Usuario{Nombre="Juan", Correo="jnava6066@gmail.com", Contrasena="1234", Nivel="Admin", DireccionImagePerfil="../Images/Usuarios/jnava6066@gmail.comJuan.jpeg"},
            new Usuario{Nombre="Alejandro", Correo="aserranoacosta841@gmail.com", Contrasena="1234", Nivel="Admin", DireccionImagePerfil="../Images/Usuarios/aserranoacosta841@gmail.comAlejandro.jpeg"},
            new Usuario{Nombre="Luis", Correo="assened200@gmail.com", Contrasena="1234", Nivel="Admin", DireccionImagePerfil="../Images/Usuarios/assened200@gmail.comLuis.jpeg"},
            new Usuario{Nombre="Erik", Correo="erikrdgr@outlook.com", Contrasena="1234", Nivel="Admin", DireccionImagePerfil="../Images/Usuarios/erikrdgr@outlook.comErik.jpeg"},
        };
        foreach (Usuario u in insertarUsuarios)
        {
            //ingresamos el objeto a la tabla de la base de datos
            _contexto.Usuario.Add(u);
        }
        _contexto.SaveChanges();
    }
}
