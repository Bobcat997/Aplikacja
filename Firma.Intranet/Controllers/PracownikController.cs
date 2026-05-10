using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Firma.Data;
using Firma.Data.Entities;

namespace Firma.Intranet.Controllers
{
    public class PracownikController : Controller
    {
        private readonly FirmaDbContext _context;

        public PracownikController(FirmaDbContext context)
        {
            _context = context;
        }

        // ====================== INDEX ======================
        public async Task<IActionResult> Index(string search = "")
        {
            var query = _context.Pracownicy
                .Include(p => p.Dzial)
                .Include(p => p.Stanowisko)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                query = query.Where(p =>
                    (p.Imie != null && p.Imie.ToLower().Contains(search)) ||
                    (p.Nazwisko != null && p.Nazwisko.ToLower().Contains(search)) ||
                    (p.Email != null && p.Email.ToLower().Contains(search)));
            }

            ViewBag.Search = search;
            return View(await query.ToListAsync());
        }

        // ====================== CREATE ======================
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pracownik pracownik)
        {
            // Obsługa pustych kluczy obcych (żeby nie było błędu 0)
            if (pracownik.DzialId == 0) pracownik.DzialId = null;
            if (pracownik.StanowiskoId == 0) pracownik.StanowiskoId = null;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(pracownik);
                    await _context.SaveChangesAsync();

                    TempData["Success"] = "Pracownik został pomyślnie dodany!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Błąd podczas zapisu: {ex.Message}");
                }
            }

            // Jeśli coś nie gra – wracamy do formularza
            return View(pracownik);
        }

        // ====================== EDIT ======================
        public async Task<IActionResult> Edit(int id)
        {
            var pracownik = await _context.Pracownicy.FindAsync(id);
            if (pracownik == null) return NotFound();
            return View(pracownik);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pracownik pracownik)
        {
            if (id != pracownik.Id) return NotFound();

            if (pracownik.DzialId == 0) pracownik.DzialId = null;
            if (pracownik.StanowiskoId == 0) pracownik.StanowiskoId = null;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pracownik);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Zmiany zostały zapisane!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Błąd podczas edycji: {ex.Message}");
                }
            }
            return View(pracownik);
        }

        // ====================== DELETE ======================
        public async Task<IActionResult> Delete(int id)
        {
            var pracownik = await _context.Pracownicy.FindAsync(id);
            if (pracownik == null) return NotFound();
            return View(pracownik);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pracownik = await _context.Pracownicy.FindAsync(id);
            if (pracownik != null)
            {
                _context.Pracownicy.Remove(pracownik);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Pracownik został usunięty.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}