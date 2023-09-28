using KanunWebsite.Areas.Admin.Filter;
using KanunWebsite.Areas.Admin.Libraries.Repository;
using KanunWebsite.Areas.Admin.ViewModel;
using KanunWebsite.Areas.Admin.ViewModelAdmin;
using KanunWebsite.Data;
using KanunWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace KanunWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    [TypeFilter(typeof(Auth))]
    public class DashboardController: Controller
    {
        private readonly ApplicationDbContext _context;
        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }
        [TypeFilter(typeof(Auth))]
        public IActionResult Index()
        {
            VMAdminBase data = default;
            User? usr = ReturnUserData();
            try
            {
                data = new()
                {
                    Fullname = usr?.FullName,
                    Token = usr?.Token,
                    Email = usr?.Email,
                    ProfileImage = usr?.ProfilePicture,
                };
            }
            catch (Exception)
            {
                ForceLogOut();
            }          
            return View(data);
        }
        private User? ReturnUserData()
        {
            return _context.Users.Where(u => u.Token == Request.Cookies["token"]).FirstOrDefault();
        }
        private IActionResult ForceLogOut()
        {
            Response.Cookies.Delete("token");
            return RedirectToAction("login", "admin"); //was login admin
        }
    }
}
