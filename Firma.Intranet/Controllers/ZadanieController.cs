using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Firma.Data;
using Firma.Data.Entities;

namespace Firma.Intranet.Controllers
{
    /// <summary>
    /// Kontroler odpowiedzialny za operacje CRUD na encji Zadanie
    /// </summary>
    public class ZadanieController : Controller
    {
        private readonly FirmaDbContext _context;

        public ZadanieController(FirmaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Lista zadań z wyszukiwaniem
        /// </summary>
        public async Task<IActionResult> Index(string search = "")
        {
            var query = _context.Zadania
                .Include(z => z.Pracownik)
                .Include(z => z.Projekt)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(z => z.Tytul.Contains(search));   // Poprawione na Tytul
            }

            ViewBag.Search = search;
            return View(await query.ToListAsync());
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Zadanie zadanie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zadanie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zadanie);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var zadanie = await _context.Zadania.FindAsync(id);
            if (zadanie == null) return NotFound();
            return View(zadanie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Zadanie zadanie)
        {
            if (id != zadanie.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(zadanie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zadanie);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var zadanie = await _context.Zadania.FindAsync(id);
            if (zadanie == null) return NotFound();
            return View(zadanie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zadanie = await _context.Zadania.FindAsync(id);
            if (zadanie != null)
            {
                _context.Zadania.Remove(zadanie);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}