using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwapnaliTask.Data;
using SwapnaliTask.Models;

namespace SwapnaliTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            this.db = db;

        }

        public IActionResult Index()
        {
            ViewBag.id = GetUserId();
            var entrylist = db.entries.Include(e => e.User).ToList();
            return View(entrylist);
        }

        protected string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public IActionResult AddEntry()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEntry(Entry entry)
        {
            entry.CreatedAt = DateTime.UtcNow;  // Set creation time
            //entry.IsDeleted = false;
            entry.UserID = int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            db.entries.Add(entry);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        public IActionResult DeleteEntry(int id)
        {
            if (id == 0)
            {
                TempData["message"] = "Entry does not Exist";
                return RedirectToAction(nameof(Index));
            }
            var entry = db.entries.FirstOrDefault(x => x.EntryID== id);

            if (entry == null) {
                TempData["message"] = "Entry not Found";
                return RedirectToAction(nameof(Index));
            }
            db.entries.Remove(entry);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
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
