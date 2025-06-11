using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmManagementTracker.Models;
using Microsoft.AspNetCore.Authorization;

namespace FarmManagementTracker.Controllers
{
    [Authorize(Roles = "Admin,Viewer,Default")]
    public class TaskController : Controller
    {
        private readonly FarmDbContext _context;

        public TaskController(FarmDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await _context.FarmTasks.ToListAsync();
            return View(tasks);
        }

        [Authorize(Roles = "Admin,Viewer")]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> Create(FarmTask task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _context.FarmTasks.FindAsync(id);
            if (task == null) return NotFound();
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> Edit(int id, FarmTask task)
        {
            if (id != task.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _context.FarmTasks.FirstOrDefaultAsync(t => t.Id == id);
            if (task == null) return NotFound();
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Viewer")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.FarmTasks.FindAsync(id);
            if (task != null)
            {
                _context.FarmTasks.Remove(task);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}



