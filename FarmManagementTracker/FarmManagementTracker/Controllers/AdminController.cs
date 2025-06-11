using FarmManagementTracker.Models;
using FarmManagementTracker.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmManagementTracker.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly FarmDbContext _context;

        public AdminController(UserManager<IdentityUser> userManager,
                               RoleManager<IdentityRole> roleManager,
                               FarmDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            var roles = _roleManager.Roles.Select(r => r.Name).ToList();

            var model = new List<UserRoleViewModel>();

            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                model.Add(new UserRoleViewModel
                {
                    UserId = user.Id,
                    Username = user.UserName,
                    Roles = userRoles.ToList(),
                    AvailableRoles = roles
                });
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null || string.IsNullOrEmpty(roleName)) return RedirectToAction("Index");

            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            await _userManager.AddToRoleAsync(user, roleName);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ResetRequests()
        {
            var requests = await _context.PasswordResetRequests
                .OrderByDescending(r => r.RequestedAt)
                .ToListAsync();

            return View(requests);
        }

        [HttpPost]
        public async Task<IActionResult> ResetUserPassword(int requestId, string newPassword, string notes)
        {
            var request = await _context.PasswordResetRequests.FindAsync(requestId);
            if (request == null || request.IsResolved) return RedirectToAction("ResetRequests");

            var user = await _userManager.FindByNameAsync(request.Username);
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

                if (result.Succeeded)
                {
                    request.IsResolved = true;
                    request.ResolutionNotes = notes;
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction("ResetRequests");
        }
    }
}





