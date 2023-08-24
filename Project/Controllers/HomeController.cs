using KanunWebsite.Data;
using KanunWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KanunWebsite.Controllers
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
            VMHome home = new()
            {
                Blogs = _context.Blogs?.Where(b => !b.IsHidden).OrderByDescending(b => b.PublishDate).ToList(),
                Categories = _context.Categories?.ToList(),
                SiteContactDetails = _context.ContactDetails?.ToList(),
                Users = _context.Users?.OrderBy(u => u.FullName).Take(4).ToList(),
                Titles = _context.Titles?.ToList(),
                Testimonials = _context.Testimonials?.OrderBy(t => t.Fullname).ToList(),
            };
            return View(home);
        }
    }
}
