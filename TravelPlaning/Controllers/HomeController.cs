using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelPlaning.Models;

namespace TravelPlaning.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Animales()
        {
            return View();
        }

        public IActionResult Proceso()
        {
            return View();
        }

        public IActionResult Donaciones()
        {
            return View();
        }

        public IActionResult Preguntas()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
