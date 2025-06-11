using FarmManagementTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmManagementTracker.Controllers
{
    public class PasswordRequestController : Controller
    {
        private readonly FarmDbContext _context;

        public PasswordRequestController(FarmDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Request()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Request(string username)
        {
            if (!string.IsNullOrWhiteSpace(username))
            {
                var request = new PasswordResetRequest
                {
                    Username = username
                };
                _context.PasswordResetRequests.Add(request);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Your request has been submitted.";
            }
            return View();
        }
    }
}

