using KanunWebsite.Data;
using KanunWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KanunWebsite.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            VMContact about = new()
            {
                SiteContactDetails = _context.ContactDetails?.ToList(),
            };
            return View(about);
        }
    }
}
