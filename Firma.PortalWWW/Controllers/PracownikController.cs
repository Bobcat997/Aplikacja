using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Firma.Data;
using Firma.Data.Entities;

namespace Firma.Portal.Controllers
{
    /// <summary>
    /// Kontroler odpowiedzialny za wyświetlanie pracowników klientom (Portal)
    /// </summary>
    public class PracownikController : Controller
    {
        private readonly FirmaDbContext _context;

        public PracownikController(FirmaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Wyświetla listę pracowników z możliwością wyszukiwania
        /// </summary>
        public async Task<IActionResult> Index(string search = "")
        {
            var query = _context.Pracownicy
                .Include(p => p.Dzial)
                .Include(p => p.Stanowisko)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                query = query.Where(p =>
                    (p.Imie != null && p.Imie.ToLower().Contains(search)) ||
                    (p.Nazwisko != null && p.Nazwisko.ToLower().Contains(search)));
            }

            return View(await query.ToListAsync());
        }
    }
}