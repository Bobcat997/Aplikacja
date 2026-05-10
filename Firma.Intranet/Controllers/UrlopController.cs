using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Firma.Data;
using Firma.Data.Entities;

namespace Firma.Intranet.Controllers
{
    /// <summary>
    /// Kontroler odpowiedzialny za operacje CRUD na encji Urlop
    /// </summary>
    public class UrlopController : Controller
    {
        private readonly FirmaDbContext _context;
        public UrlopController(FirmaDbContext context) => _context = context;

        public async Task<IActionResult> Index(string search = "")
        {
            var query = _context.Urlopy
                .Include(u => u.Pracownik)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(u => u.Pracownik!.Imie.Contains(search) || u.Pracownik!.Nazwisko.Contains(search));

            ViewBag.Search = search;
            return View(await query.ToListAsync());
        }

        public IActionResult Create() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Urlop urlop)
        {
            if (ModelState.IsValid) { _context.Add(urlop); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
            return View(urlop);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var urlop = await _context.Urlopy.FindAsync(id);
            if (urlop == null) return NotFound();
            return View(urlop);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Urlop urlop)
        {
            if (id != urlop.Id) return NotFound();
            if (ModelState.IsValid) { _context.Update(urlop); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
            return View(urlop);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var urlop = await _context.Urlopy.FindAsync(id);
            if (urlop == null) return NotFound();
            return View(urlop);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var urlop = await _context.Urlopy.FindAsync(id);
            if (urlop != null) { _context.Urlopy.Remove(urlop); await _context.SaveChangesAsync(); }
            return RedirectToAction(nameof(Index));
        }
    }
}