using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmManagementTracker.Models;
using Microsoft.AspNetCore.Authorization;

namespace FarmManagementTracker.Controllers
{
    [Authorize(Roles = "Admin,Viewer,Default")]
    public class VaccineController : Controller
    {
        private readonly FarmDbContext _context;

        public VaccineController(FarmDbContext context)
        {
            _context = context;
        }

        // View vaccinations for a specific animal
        public async Task<IActionResult> Index(int animalId)
        {
            var animal = await _context.Animals.FindAsync(animalId);
            if (animal == null) return NotFound();

            var records = await _context.VaccinationRecords
                .Where(v => v.AnimalId == animalId)
                .ToListAsync();

            ViewBag.AnimalName = animal.Name;
            ViewBag.AnimalId = animalId;
            return View(records);
        }

        // View all vaccinations
        public async Task<IActionResult> AllVaccines()
        {
            var records = await _context.VaccinationRecords
                .Include(v => v.Animal)
                .ToListAsync();

            return View(records);
        }

        // Admin and Viewer: Create
        [Authorize(Roles = "Admin,Viewer")]
        public IActionResult Create(int animalId)
        {
            ViewBag.AnimalId = animalId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> Create(VaccinationRecord record)
        {
            if (ModelState.IsValid)
            {
                _context.Add(record);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { animalId = record.AnimalId });
            }
            ViewBag.AnimalId = record.AnimalId;
            return View(record);
        }

        // Admin and Viewer: Edit
        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> Edit(int id)
        {
            var record = await _context.VaccinationRecords.FindAsync(id);
            if (record == null) return NotFound();
            return View(record);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> Edit(int id, VaccinationRecord record)
        {
            if (id != record.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(record);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.VaccinationRecords.Any(v => v.Id == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index), new { animalId = record.AnimalId });
            }
            return View(record);
        }

        // Admin and Viewer: Delete
        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.VaccinationRecords.FindAsync(id);
            if (record == null) return NotFound();

            return View(record);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var record = await _context.VaccinationRecords.FindAsync(id);
            if (record != null)
            {
                _context.VaccinationRecords.Remove(record);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index), new { animalId = record?.AnimalId ?? 0 });
        }

        private bool VaccinationRecordExists(int id)
        {
            return _context.VaccinationRecords.Any(e => e.Id == id);
        }
    }
}



