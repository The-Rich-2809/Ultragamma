﻿using Microsoft.AspNetCore.Mvc;

namespace Ultragamma.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
