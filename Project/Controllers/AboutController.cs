using KanunWebsite.Data;
using KanunWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KanunWebsite.Controllers
{
    public class AboutController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AboutController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            VMAbout about = new()
            {
                Users = _context.Users?.OrderBy(u => u.FullName).ToList(),
                Titles = _context.Titles?.ToList(),
                SiteContactDetails = _context.ContactDetails?.ToList(),
            };
            return View(about);
        }
    }
}
