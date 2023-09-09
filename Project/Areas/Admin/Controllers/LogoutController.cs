using KanunWebsite.Areas.Admin.Filter;
using KanunWebsite.Data;
using KanunWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KanunWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    public class LogoutController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LogoutController(ApplicationDbContext context)
        {
            _context = context;
        }

        [TypeFilter(typeof(Auth))]
        public IActionResult Index()
        {
            User _user = RouteData.Values["loggedUser"] as User;
            _user.Token = null;
            _context.SaveChanges();
            Response.Cookies.Delete("token");
            return RedirectToAction("login","admin");
        }
    }
}
