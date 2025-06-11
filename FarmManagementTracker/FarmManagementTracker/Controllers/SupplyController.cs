using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmManagementTracker.Models;
using Microsoft.AspNetCore.Authorization;

namespace FarmManagementTracker.Controllers
{
    [Authorize(Roles = "Admin,Viewer,Default")]
    public class SupplyController : Controller
    {
        private readonly FarmDbContext _context;

        public SupplyController(FarmDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var supplies = await _context.SupplyItems.ToListAsync();
            return View(supplies);
        }

        [Authorize(Roles = "Admin,Viewer")]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> Create(SupplyItem item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.SupplyItems.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> Edit(int id, SupplyItem item)
        {
            if (id != item.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.SupplyItems.FirstOrDefaultAsync(s => s.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.SupplyItems.FindAsync(id);
            if (item != null)
            {
                _context.SupplyItems.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}




