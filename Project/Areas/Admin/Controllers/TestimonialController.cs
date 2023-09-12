using KanunWebsite.Areas.Admin.Filter;
using KanunWebsite.Data;
using Microsoft.AspNetCore.Mvc;

namespace KanunWebsite.Areas.Admin.Controllers
{

    [Area("admin")]
    [Route("admin/[controller]/[action]")]
    [TypeFilter(typeof(Auth))]
    public class TestimonialController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TestimonialController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
