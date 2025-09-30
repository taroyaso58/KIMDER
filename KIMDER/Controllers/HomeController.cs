using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KucukkoyIHL.Data;
using KucukkoyIHL.Models;
using System.Diagnostics;

namespace KucukkoyIHL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> News()
        {
            var news = await _context.News
                .Where(n => n.IsActive)
                .OrderByDescending(n => n.CreatedDate)
                .ToListAsync();
            return View(news);
        }

        public async Task<IActionResult> NewsDetail(int id)
        {
            var news = await _context.News.FindAsync(id);
            if (news == null || !news.IsActive)
            {
                return NotFound();
            }
            return View(news);
        }

        public async Task<IActionResult> Events()
        {
            var events = await _context.Events
                .Where(e => e.IsActive)
                .OrderBy(e => e.EventDate)
                .ToListAsync();
            return View(events);
        }

        public async Task<IActionResult> EventDetail(int id)
        {
            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null || !eventItem.IsActive)
            {
                return NotFound();
            }
            return View(eventItem);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}