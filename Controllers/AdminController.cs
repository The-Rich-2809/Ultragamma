using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using Ultragamma.Models;
using Ultragamma.Helpers;
using Ultragamma.Providers;
using Microsoft.AspNetCore.Http;

namespace Ultragamma.Controllers
{
    public class AdminController : Controller
    {
        private HelperUploadFiles helperUpload;
        public readonly ApplicationDbContex _contexto;
        public AdminController(HelperUploadFiles helperUpload, ApplicationDbContex contexto)
        {
            _contexto = contexto;
            this.helperUpload = helperUpload;
        }
        //Verificar Cookies
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
                        break;
                    }
                }
            }
            else
            {
                ViewBag.Entrar = "No";
            }
        }

        //Vista de Inicio del Admin
        public IActionResult Inicio()
        {
            Cookies();
            return View();
        }

        //Vista del Almacen
        public IActionResult Almacen()
        {
            List<Producto> listaProductos = _contexto.Producto.ToList();
            Cookies();
            return View(listaProductos);
        }
        [HttpGet]
        public IActionResult NuevoProducto()
        {
            Cookies();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>NuevoProducto(Producto producto, IFormFile[] Imagen)
        {
            var productos = new ProductosModel(_contexto);
            productos.NuevoProducto(producto);
            for (int i = 0; i < Imagen.Length; i++)
            {
                string nombreImagen = producto.Id + "_" + i + "_" + Imagen[i].FileName;
                await this.helperUpload.UploadFilesAsync(Imagen[i], nombreImagen, Folders.Productos);
                AgregarImagesProductos(nombreImagen);
            }
            Cookies();
            return RedirectToAction(nameof(Almacen));
        }
        public void AgregarImagesProductos(string DireccionImage)
        {
            int conta = 0;
            List<Producto> listaProductos = _contexto.Producto.ToList();
            foreach(var i in listaProductos)
            {
                conta++;
                if(conta == listaProductos.Count)
                {
                    ImagenesProductos imagenesProductos = new ImagenesProductos();
                    imagenesProductos.ProductoId = i.Id;
                    imagenesProductos.DireccionImage = "../Images/Productos/" + DireccionImage;
                    _contexto.imagenesProductos.Add(imagenesProductos);
                    _contexto.SaveChanges();
                }
            }
        }
        [HttpGet]
        public IActionResult EditarProducto(int id)
        {
            var Producto = _contexto.Producto.FirstOrDefault(c => c.Id == id);
            Cookies();
            return View(Producto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>EditarProducto(IFormFile[] Imagen, Producto producto)
        {
            var productos = new ProductosModel(_contexto);
            productos.EditarProducto(producto);
            if (Imagen != null)
            {
                for (int i = 0; i < Imagen.Length; i++)
                {
                    string nombreImagen = producto.Id + "_" + i + "_" + Imagen[i].FileName;
                    await this.helperUpload.UploadFilesAsync(Imagen[i], nombreImagen, Folders.Productos);
                    EditarImagesProductos(producto.Id, nombreImagen);
                }
            }
            Cookies();
            return RedirectToAction(nameof(Almacen));
        }
        public void EditarImagesProductos(int id, string DireccionImage)
        {
            List<ImagenesProductos> listaImages = _contexto.imagenesProductos.ToList();
            foreach (var i in listaImages)
            {
                if(i.Id == id)
                {
                    _contexto.imagenesProductos.Remove(i);
                    _contexto.SaveChanges();
                }
            }
            int conta = 0;
            List<Producto> listaProductos = _contexto.Producto.ToList();
            foreach (var i in listaProductos)
            {
                conta++;
                if (conta == listaProductos.Count)
                {
                    ImagenesProductos imagenesProductos = new ImagenesProductos();
                    imagenesProductos.ProductoId = i.Id;
                    imagenesProductos.DireccionImage = "../Images/Productos/" + DireccionImage;
                    _contexto.imagenesProductos.Add(imagenesProductos);
                    _contexto.SaveChanges();
                }
            }
        }
        [HttpGet]
        public IActionResult EliminarProducto(int? id)
        {
            var Producto = _contexto.Producto.FirstOrDefault(c => c.Id == id);
            Cookies();
            return View(Producto);
        }
        [HttpPost]
        public IActionResult EliminarProducto(int id)
        {
            var Producto = _contexto.Producto.FirstOrDefault(c => c.Id == id);
            _contexto.Producto.Remove(Producto);
            _contexto.SaveChanges();
            EliminarImagesProductos(Producto.Id);
            Cookies();
            return RedirectToAction(nameof(Almacen));
        }
        public void EliminarImagesProductos(int id)
        {
            List<ImagenesProductos> listaImages = _contexto.imagenesProductos.ToList();
            foreach (var i in listaImages)
            {
                if (i.Id == id)
                {
                    _contexto.imagenesProductos.Remove(i);
                    _contexto.SaveChanges();
                }
            }
        }

        //Vista de Usuario
        public IActionResult Usuarios()
        {
            List<Usuario> listaUsuarios = _contexto.Usuario.ToList();
            Cookies();
            return View(listaUsuarios);
        }
        [HttpGet]
        public IActionResult EditarUsuarios(string id)
        {
            var Usuario = _contexto.Usuario.FirstOrDefault(c => c.Correo == id);
            FotoPerfil = Usuario.DireccionImagePerfil;
            Cookies();
            return View(Usuario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarUsuarios(IFormFile Imagen, Usuario usuario, string id, string Contrasena1, string Contrasena2)
        {
            var usuarios = new RegistroModel(_contexto);
            if (Imagen != null)
            {
                string nombreImagen = usuario.Correo + Imagen.FileName;
                await this.helperUpload.UploadFilesAsync(Imagen, nombreImagen, Folders.Images);
                usuario.DireccionImagePerfil = "../Images/Usuarios/" + nombreImagen;
            }
            else
            {
                usuario.DireccionImagePerfil = FotoPerfil;
            }
            if(Contrasena1 != null)
            {
                usuario.Contrasena = Contrasena1;
            }

            usuarios.EditarUsuario(usuario);
            Cookies();
            return RedirectToAction(nameof(Usuarios));
        }
        private static string FotoPerfil { get; set; } = String.Empty;
        [HttpGet]
        public IActionResult EliminarUsuario(string? id)
        {
            var Usuario = _contexto.Usuario.FirstOrDefault(c => c.Correo == id);
            Cookies();
            return View(Usuario);
        }
        [HttpPost]
        public IActionResult EliminarUsuario(string id, string Correo)
        {
            var Usuario = _contexto.Usuario.FirstOrDefault(c => c.Correo == id);
            _contexto.Usuario.Remove(Usuario);
            _contexto.SaveChanges();
            Cookies();
            return RedirectToAction(nameof(Usuarios));
        }

        //Vista de Compras
        public IActionResult Compras()
        {
            List<OrdenCompra> listaOrdenCompra = _contexto.OrdenCompra.ToList();
            Cookies();
            return View(listaOrdenCompra);
        }
        public IActionResult OrdenDetalles(int id, int idDireccion)
        {
            Cookies();
            ViewBag.Direccion = _contexto.Direccion.FirstOrDefault(c => c.Id == idDireccion);
            ViewBag.Detalles = _contexto.DetalleOrden.ToList();
            ViewBag.Productos = _contexto.Producto.ToList();
            ViewBag.IdOrden = id;
            return View();
        }

        //Vista de Ventas
        public IActionResult VentasTerminadas()
        {
            Cookies();
            return View();
        }
    }
}
