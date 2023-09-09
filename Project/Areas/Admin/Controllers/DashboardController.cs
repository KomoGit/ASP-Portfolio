using KanunWebsite.Areas.Admin.Filter;
using KanunWebsite.Areas.Admin.ViewModel;
using KanunWebsite.Data;
using KanunWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace KanunWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }
        [TypeFilter(typeof(Auth))]
        public IActionResult Index()
        {
            User? usr = ReturnUserData();
            VMUser dashboard = new() {
                Fullname = usr.FullName,
                Token = usr.Token,
                Email = usr.Email,
                ProfileImage = usr.ProfilePicture,
            };
            return View(dashboard);
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Blog()
        {
            User? usr = ReturnUserData();
            VMUser dashboard = new()
            {
                Fullname = usr.FullName,
                Token = usr.Token,
                Email = usr.Email,
                ProfileImage = usr.ProfilePicture,
            };
            return View(dashboard);
        }

        private User? ReturnUserData()
        {
            return _context.Users.Where(u => u.Token == Request.Cookies["token"]).First();
        }
    }
}
