using KanunWebsite.Data;
using KanunWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                Blogs = _context.Blogs?.OrderByDescending(o => o.PublishDate).ToList(),
                SiteContactDetails = _context.ContactDetails?.ToList(),

            };
            return View(home);
        }
    }
}
