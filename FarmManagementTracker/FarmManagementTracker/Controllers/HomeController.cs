using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FarmManagementTracker.Models;
using FarmManagementTracker.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace FarmManagementTracker.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private static readonly List<string> _quotes = new()
        {
            "“The farmer has to be an optimist or he wouldn’t still be a farmer.” – Will Rogers",
            "“Farming looks mighty easy when your plow is a pencil.” – Dwight D. Eisenhower",
            "“To forget how to dig the earth and to tend the soil is to forget ourselves.” – Gandhi",
            "“Farming is a profession of hope.” – Brian Brett",
            "“No race can prosper till it learns there is as much dignity in tilling a field as in writing a poem.” – Booker T. Washington"
        };

        private readonly ILogger<HomeController> _logger;
        private readonly FarmDbContext _context;

        public HomeController(ILogger<HomeController> logger, FarmDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var animals = await _context.Animals.ToListAsync();
            var supplies = await _context.SupplyItems.ToListAsync();
            var tasks = await _context.FarmTasks.ToListAsync();

            int totalAnimals = animals.Count;
            int uniqueTypes = animals.Select(a => a.Type).Distinct().Count();

            DateTime today = DateTime.Today;

            // Low Supplies (Quantity <= 2)
            var lowSupplies = supplies
                .Where(s => s.Quantity <= 2)
                .ToList();

            // Overdue Tasks
            var overdueTasks = tasks
                .Where(t => t.NextDueDate < today)
                .ToList();

            // Upcoming Vaccinations (Next 30 days, include animal name)
            var upcomingVaccines = await _context.VaccinationRecords
                .Where(v => v.NextDueDate.HasValue && v.NextDueDate.Value <= today.AddDays(30))
                .Join(
                    _context.Animals,
                    v => v.AnimalId,
                    a => a.Id,
                    (v, a) => new VaccinationReminder
                    {
                        AnimalName = a.Name,
                        VaccineName = v.VaccineName,
                        DueDate = v.NextDueDate
                    }
                )
                .OrderBy(v => v.DueDate)
                .ToListAsync();

            // Random Quote
            var random = new Random();
            string quote = _quotes[random.Next(_quotes.Count)];

            // ViewBag Setup
            ViewBag.TotalAnimals = totalAnimals;
            ViewBag.UniqueTypes = uniqueTypes;
            ViewBag.LowSupplies = lowSupplies;
            ViewBag.OverdueTasks = overdueTasks;
            ViewBag.UpcomingVaccines = upcomingVaccines;
            ViewBag.Quote = quote;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}




