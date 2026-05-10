using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Firma.Data;
using Firma.Data.Entities;

namespace Firma.Intranet.Controllers
{
    /// <summary>
    /// Kontroler odpowiedzialny za operacje CRUD na encji Dział
    /// </summary>
    public class DzialController : Controller
    {
        private readonly FirmaDbContext _context;

        public DzialController(FirmaDbContext context) => _context = context;

        /// <summary>
        /// Lista wszystkich działów z wyszukiwaniem
        /// </summary>
        public async Task<IActionResult> Index(string search = "")
        {
            var query = _context.Dzialy.AsQueryable();
            if (!string.IsNullOrEmpty(search))
                query = query.Where(d => d.Nazwa.Contains(search));

            ViewBag.Search = search;
            return View(await query.ToListAsync());
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Dzial dzial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dzial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dzial);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dzial = await _context.Dzialy.FindAsync(id);
            if (dzial == null) return NotFound();
            return View(dzial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Dzial dzial)
        {
            if (id != dzial.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(dzial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dzial);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dzial = await _context.Dzialy.FindAsync(id);
            if (dzial == null) return NotFound();
            return View(dzial);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dzial = await _context.Dzialy.FindAsync(id);
            if (dzial != null)
            {
                _context.Dzialy.Remove(dzial);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}