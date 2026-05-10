using Firma.PortalWWW.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Firma.PortalWWW.Controllers
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

        // ================= NOWE STRONY =================
        public IActionResult Oferta()
        {
            return View();
        }

        public IActionResult Zajecia()
        {
            return View();
        }

        public IActionResult Trenerzy()
        {
            return View();
        }

        public IActionResult Kontakt()
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