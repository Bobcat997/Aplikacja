using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Firma.Data;
using Firma.Data.Entities;

namespace Firma.Intranet.Controllers
{
    /// <summary>
    /// Kontroler odpowiedzialny za operacje CRUD na encji Projekt
    /// </summary>
    public class ProjektController : Controller
    {
        private readonly FirmaDbContext _context;
        public ProjektController(FirmaDbContext context) => _context = context;

        public async Task<IActionResult> Index(string search = "")
        {
            var query = _context.Projekty.AsQueryable();
            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Nazwa.Contains(search) || (p.Opis != null && p.Opis.Contains(search)));

            ViewBag.Search = search;
            return View(await query.ToListAsync());
        }

        public IActionResult Create() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Projekt projekt)
        {
            if (ModelState.IsValid) { _context.Add(projekt); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
            return View(projekt);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var projekt = await _context.Projekty.FindAsync(id);
            if (projekt == null) return NotFound();
            return View(projekt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Projekt projekt)
        {
            if (id != projekt.Id) return NotFound();
            if (ModelState.IsValid) { _context.Update(projekt); await _context.SaveChangesAsync(); return RedirectToAction(nameof(Index)); }
            return View(projekt);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var projekt = await _context.Projekty.FindAsync(id);
            if (projekt == null) return NotFound();
            return View(projekt);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projekt = await _context.Projekty.FindAsync(id);
            if (projekt != null) { _context.Projekty.Remove(projekt); await _context.SaveChangesAsync(); }
            return RedirectToAction(nameof(Index));
        }
    }
}