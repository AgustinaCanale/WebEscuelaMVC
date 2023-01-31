using Microsoft.AspNetCore.Mvc;
using System;

namespace WebEscuelaMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Nombre = "Bienvenido al sistema de Alumnos";
            ViewBag.Fecha = DateTime.Now;
            return View();
        }
    }
}
