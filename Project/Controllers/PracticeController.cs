using KanunWebsite.Data;
using KanunWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KanunWebsite.Controllers
{
    public class PracticeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PracticeController(ApplicationDbContext context)
        {
            _context = context;   
        }
        public IActionResult Index()
        {
            VMPractice practice = new()
            {

            };
            return View(practice);
        }
    }
}
