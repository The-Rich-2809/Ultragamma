using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ultragamma.Models;

namespace Ultragamma.Controllers;

public class ProductosController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public ProductosController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

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




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
