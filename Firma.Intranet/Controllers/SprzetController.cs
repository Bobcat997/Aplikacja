using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Firma.Data;
using Firma.Data.Entities;

namespace Firma.Intranet.Controllers
{
    /// <summary>
    /// Kontroler odpowiedzialny za operacje CRUD na encji Sprzęt
    /// </summary>
    public class SprzetController : Controller
    {
        private readonly FirmaDbContext _context;

        public SprzetController(FirmaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Lista sprzętu z wyszukiwaniem
        /// </summary>
        public async Task<IActionResult> Index(string search = "")
        {
            var query = _context.Sprzet
                .Include(s => s.Pracownik)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(s =>
                    s.Nazwa.Contains(search) ||
                    (s.NumerSeryjny != null && s.NumerSeryjny.Contains(search)));
            }

            ViewBag.Search = search;
            return View(await query.ToListAsync());
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sprzet sprzet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sprzet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sprzet);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var sprzet = await _context.Sprzet.FindAsync(id);
            if (sprzet == null) return NotFound();
            return View(sprzet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Sprzet sprzet)
        {
            if (id != sprzet.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(sprzet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sprzet);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var sprzet = await _context.Sprzet.FindAsync(id);
            if (sprzet == null) return NotFound();
            return View(sprzet);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sprzet = await _context.Sprzet.FindAsync(id);
            if (sprzet != null)
            {
                _context.Sprzet.Remove(sprzet);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}