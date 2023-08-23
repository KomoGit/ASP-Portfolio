using KanunWebsite.Data;
using KanunWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
                Users = _context.Users?.ToList(),
            };
            return View(team);
        }
    }
}
