using KanunWebsite.Data;
using KanunWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace KanunWebsite.Controllers
{
    public class TeamController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TeamController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            VMAttorneys team = new()
            {
                Users = _context.Users?.OrderBy(u => u.FullName).ToList(),
                Titles = _context.Titles?.ToList(),
                SiteContactDetails = _context.ContactDetails?.ToList(),
            };
            return View(team);
        }
    }
}
