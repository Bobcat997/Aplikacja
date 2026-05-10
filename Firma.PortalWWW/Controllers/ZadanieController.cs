using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Firma.Data;
using Firma.Data.Entities;

namespace Firma.Portal.Controllers
{
    /// <summary>
    /// Kontroler odpowiedzialny za wyświetlanie zadań
    /// </summary>
    public class ZadanieController : Controller
    {
        private readonly FirmaDbContext _context;

        public ZadanieController(FirmaDbContext context) => _context = context;

        public async Task<IActionResult> Index(string search = "")
        {
            var query = _context.Zadania
                .Include(z => z.Projekt)
                .Include(z => z.Pracownik)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                query = query.Where(z => z.Tytul.ToLower().Contains(search));
            }

            return View(await query.ToListAsync());
        }
    }
}