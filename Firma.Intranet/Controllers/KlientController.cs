using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Firma.Data;
using Firma.Data.Entities;

namespace Firma.Intranet.Controllers
{
    /// <summary>
    /// Kontroler odpowiedzialny za operacje CRUD na encji Klient
    /// </summary>
    public class KlientController : Controller
    {
        private readonly FirmaDbContext _context;
        public KlientController(FirmaDbContext context) => _context = context;

        public async Task<IActionResult> Index(string search = "")
        {
            var query = _context.Klienci.AsQueryable();
            if (!string.IsNullOrEmpty(search))
                query = query.Where(k => k.NazwaFirmy.Contains(search) || k.Email!.Contains(search));

            ViewBag.Search = search;
            return View(await query.ToListAsync());
        }

        public IActionResult Create() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Klient klient)
        {
            if (ModelState.IsValid) { _context.Add(klient); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
            return View(klient);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var klient = await _context.Klienci.FindAsync(id);
            if (klient == null) return NotFound();
            return View(klient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Klient klient)
        {
            if (id != klient.Id) return NotFound();
            if (ModelState.IsValid) { _context.Update(klient); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
            return View(klient);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var klient = await _context.Klienci.FindAsync(id);
            if (klient == null) return NotFound();
            return View(klient);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klient = await _context.Klienci.FindAsync(id);
            if (klient != null) { _context.Klienci.Remove(klient); await _context.SaveChangesAsync(); }
            return RedirectToAction(nameof(Index));
        }
    }
}