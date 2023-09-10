using KanunWebsite.Areas.Admin.Filter;
using KanunWebsite.Data;
using KanunWebsite.Models;
using KanunWebsite.Models.Blog;
using Microsoft.AspNetCore.Mvc;

namespace KanunWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    [TypeFilter(typeof(Auth))]
    public class NewsletterController : Controller
    {
        private readonly ApplicationDbContext _context;
        public NewsletterController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            NewsletterSubscriber? subscriber = _context.Subscribers.Find(id);
            _context.Subscribers.Remove(subscriber);
            _context.SaveChanges();
            return RedirectToAction("newsletter", "admin");
        }
    }
}
