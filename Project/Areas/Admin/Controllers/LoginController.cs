using KanunWebsite.Areas.Admin.ViewModel;
using KanunWebsite.Data;
using KanunWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace KanunWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    public class LoginController : Controller
    {
        private User _user => RouteData.Values["loggedUser"] as User;
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost] //This might cause issues.
        public IActionResult Login(VMLogin login)
        {
            return View();
        }
    }
}
