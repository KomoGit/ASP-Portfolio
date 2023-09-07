using CryptoHelper;
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
            if (Request.Cookies["token"]  != null)
            {
                return RedirectToAction("dashboard", "admin");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Index(VMLogin model)
        {
            Console.WriteLine("Login works");
            if (ModelState.IsValid)
            {
                User user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
                if (user != null && Crypto.VerifyHashedPassword(user.Password,model.Password)) 
                {
                    user.Token = Guid.NewGuid().ToString();
                    _context.SaveChanges();
                    Response.Cookies.Append("token",user.Token, new CookieOptions
                    {
                        Expires  = model.RememberUser ? DateTimeOffset.Now.AddDays(24) : null,    
                        HttpOnly = true
                    });
                    return RedirectToAction("dashboard","admin");
                }
                ModelState.AddModelError("Password","Email or Password Is Incorrect. Check the details.");
            }
            return View(model);
        }
    }
}
