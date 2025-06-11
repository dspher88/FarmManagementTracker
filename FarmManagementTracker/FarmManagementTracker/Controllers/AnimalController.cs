using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmManagementTracker.Models;
using Microsoft.AspNetCore.Authorization;

namespace FarmManagementTracker.Controllers
{
    [Authorize(Roles = "Admin,Viewer,Default")]
    public class AnimalController : Controller
    {
        private readonly FarmDbContext _context;

        public AnimalController(FarmDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var animals = await _context.Animals.ToListAsync();
            return View(animals);
        }

        [Authorize(Roles = "Admin,Viewer")]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> Create(Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animal);
        }

        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> Edit(int id)
        {
            var animal = await _context.Animals.FindAsync(id);
            if (animal == null) return NotFound();
            return View(animal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> Edit(int id, Animal animal)
        {
            if (id != animal.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animal);
        }

        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> Delete(int id)
        {
            var animal = await _context.Animals.FindAsync(id);
            if (animal == null) return NotFound();
            return View(animal);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animal = await _context.Animals.FindAsync(id);
            if (animal != null)
            {
                _context.Animals.Remove(animal);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}




