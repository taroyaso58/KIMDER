using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KucukkoyIHL.Data;
using KucukkoyIHL.Models;

namespace KucukkoyIHL.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Admin Ana Sayfa
        public IActionResult Index()
        {
            return View();
        }

        // ====== HABERLER YÖNETİMİ ======
        
        public async Task<IActionResult> NewsList()
        {
            var news = await _context.News.OrderByDescending(n => n.CreatedDate).ToListAsync();
            return View(news);
        }

        public IActionResult CreateNews()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNews(News news)
        {
            if (ModelState.IsValid)
            {
                news.CreatedDate = DateTime.Now;
                _context.Add(news);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Haber başarıyla eklendi!";
                return RedirectToAction(nameof(NewsList));
            }
            return View(news);
        }

        public async Task<IActionResult> EditNews(int? id)
        {
            if (id == null) return NotFound();
            var news = await _context.News.FindAsync(id);
            if (news == null) return NotFound();
            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNews(int id, News news)
        {
            if (id != news.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Haber başarıyla güncellendi!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(NewsList));
            }
            return View(news);
        }

        public async Task<IActionResult> DeleteNews(int? id)
        {
            if (id == null) return NotFound();
            var news = await _context.News.FindAsync(id);
            if (news == null) return NotFound();
            return View(news);
        }

        [HttpPost, ActionName("DeleteNews")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteNewsConfirmed(int id)
        {
            var news = await _context.News.FindAsync(id);
            if (news != null)
            {
                _context.News.Remove(news);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Haber başarıyla silindi!";
            }
            return RedirectToAction(nameof(NewsList));
        }

        // ====== ETKİNLİKLER YÖNETİMİ ======
        
        public async Task<IActionResult> EventsList()
        {
            var events = await _context.Events.OrderByDescending(e => e.EventDate).ToListAsync();
            return View(events);
        }

        public IActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEvent(Event eventItem)
        {
            if (ModelState.IsValid)
            {
                eventItem.CreatedDate = DateTime.Now;
                _context.Add(eventItem);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Etkinlik başarıyla eklendi!";
                return RedirectToAction(nameof(EventsList));
            }
            return View(eventItem);
        }

        public async Task<IActionResult> EditEvent(int? id)
        {
            if (id == null) return NotFound();
            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null) return NotFound();
            return View(eventItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEvent(int id, Event eventItem)
        {
            if (id != eventItem.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventItem);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Etkinlik başarıyla güncellendi!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(eventItem.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(EventsList));
            }
            return View(eventItem);
        }

        public async Task<IActionResult> DeleteEvent(int? id)
        {
            if (id == null) return NotFound();
            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem == null) return NotFound();
            return View(eventItem);
        }

        [HttpPost, ActionName("DeleteEvent")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEventConfirmed(int id)
        {
            var eventItem = await _context.Events.FindAsync(id);
            if (eventItem != null)
            {
                _context.Events.Remove(eventItem);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Etkinlik başarıyla silindi!";
            }
            return RedirectToAction(nameof(EventsList));
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.Id == id);
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}