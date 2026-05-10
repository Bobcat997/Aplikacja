using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Firma.Data;
using Firma.Data.Entities;

namespace Firma.Portal.Controllers
{
    /// <summary>
    /// Kontroler odpowiedzialny za wyświetlanie projektów klientom
    /// </summary>
    public class ProjektController : Controller
    {
        private readonly FirmaDbContext _context;

        public ProjektController(FirmaDbContext context) => _context = context;

        public async Task<IActionResult> Index(string search = "")
        {
            var query = _context.Projekty.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                query = query.Where(p =>
                    p.Nazwa.ToLower().Contains(search) ||
                    (p.Opis != null && p.Opis.ToLower().Contains(search)));
            }

            return View(await query.ToListAsync());
        }
    }
}