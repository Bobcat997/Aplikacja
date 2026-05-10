using Firma.Intranet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Firma.Intranet.Controllers
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

     
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Grafik()
        {
            return View();
        }

        public IActionResult Klienci()
        {
            return View();
        }

        public IActionResult Raporty()
        {
            return View();
        }

        public IActionResult Sprzet()
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