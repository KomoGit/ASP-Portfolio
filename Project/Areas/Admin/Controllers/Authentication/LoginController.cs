using CryptoHelper;
using KanunWebsite.Areas.Admin.Filter;
using KanunWebsite.Areas.Admin.ViewModel;
using KanunWebsite.Data;
using KanunWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace KanunWebsite.Areas.Admin.Controllers.Authentication
{
    [Area("admin")]
    public class LoginController : Controller
    {
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
        [HttpPost]
        public IActionResult Index(VMLogin model)
        {
            if (ModelState.IsValid)
            {
                User user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
                if (user != null && Crypto.VerifyHashedPassword(user.Password, model.Password) && user.LoginFails < 3)
                {
                    user.Token = Guid.NewGuid().ToString();
                    user.LoginFails = 0;
                    _context.SaveChanges();
                    Response.Cookies.Append("token", user.Token, new CookieOptions
                    {
                        Expires = model.RememberUser ? DateTimeOffset.Now.AddDays(24) : null,
                        HttpOnly = true
                    });
                    return RedirectToAction("dashboard", "admin");
                }
                //Draw backs, accounts can be spammed by bot networks. We can block the IP addresses instead.
                if(user.LoginFails >= 3)
                {
                    ModelState.AddModelError("Password", $"Account locked due to {user.LoginFails} failed login attemps. Please contact administrator.");
                }
                ModelState.AddModelError("Password", "Email or Password Is Incorrect. Check the details.");
                user.LoginFails++;
                _context.SaveChanges();
            }
            return View(model);
        }
    }
}
