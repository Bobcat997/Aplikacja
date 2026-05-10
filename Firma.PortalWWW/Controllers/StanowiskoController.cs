using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Firma.Data;
using Firma.Data.Entities;

namespace Firma.Portal.Controllers
{
    /// <summary>
    /// Kontroler odpowiedzialny za wyświetlanie stanowisk
    /// </summary>
    public class StanowiskoController : Controller
    {
        private readonly FirmaDbContext _context;

        public StanowiskoController(FirmaDbContext context) => _context = context;

        public async Task<IActionResult> Index(string search = "")
        {
            var query = _context.Stanowiska.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                query = query.Where(s => s.Nazwa.ToLower().Contains(search));
            }

            return View(await query.ToListAsync());
        }
    }
}