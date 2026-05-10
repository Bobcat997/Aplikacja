using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Firma.Data;
using Firma.Data.Entities;

namespace Firma.Portal.Controllers
{
    /// <summary>
    /// Kontroler odpowiedzialny za wyświetlanie działów klientom
    /// </summary>
    public class DzialController : Controller
    {
        private readonly FirmaDbContext _context;

        public DzialController(FirmaDbContext context) => _context = context;

        public async Task<IActionResult> Index(string search = "")
        {
            var query = _context.Dzialy.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                query = query.Where(d => d.Nazwa.ToLower().Contains(search));
            }

            return View(await query.ToListAsync());
        }
    }
}