using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Firma.Data;
using Firma.Data.Entities;

namespace Firma.Intranet.Controllers
{
    /// <summary>
    /// Kontroler odpowiedzialny za operacje CRUD na encji Stanowisko
    /// </summary>
    public class StanowiskoController : Controller
    {
        private readonly FirmaDbContext _context;
        public StanowiskoController(FirmaDbContext context) => _context = context;

        public async Task<IActionResult> Index(string search = "")
        {
            var query = _context.Stanowiska.AsQueryable();
            if (!string.IsNullOrEmpty(search))
                query = query.Where(s => s.Nazwa.Contains(search));

            ViewBag.Search = search;
            return View(await query.ToListAsync());
        }

        public IActionResult Create() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Stanowisko stanowisko)
        {
            if (ModelState.IsValid) { _context.Add(stanowisko); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
            return View(stanowisko);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var stanowisko = await _context.Stanowiska.FindAsync(id);
            if (stanowisko == null) return NotFound();
            return View(stanowisko);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Stanowisko stanowisko)
        {
            if (id != stanowisko.Id) return NotFound();
            if (ModelState.IsValid) { _context.Update(stanowisko); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
            return View(stanowisko);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var stanowisko = await _context.Stanowiska.FindAsync(id);
            if (stanowisko == null) return NotFound();
            return View(stanowisko);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stanowisko = await _context.Stanowiska.FindAsync(id);
            if (stanowisko != null) { _context.Stanowiska.Remove(stanowisko); await _context.SaveChangesAsync(); }
            return RedirectToAction(nameof(Index));
        }
    }
}