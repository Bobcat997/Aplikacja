using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Firma.Data;
using Firma.Data.Entities;

namespace Firma.Portal.Controllers
{
    /// <summary>
    /// Kontroler odpowiedzialny za wyświetlanie klientów
    /// </summary>
    public class KlientController : Controller
    {
        private readonly FirmaDbContext _context;

        public KlientController(FirmaDbContext context) => _context = context;

        public async Task<IActionResult> Index(string search = "")
        {
            var query = _context.Klienci.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                query = query.Where(k => k.NazwaFirmy.ToLower().Contains(search));
            }

            return View(await query.ToListAsync());
        }
    }
}