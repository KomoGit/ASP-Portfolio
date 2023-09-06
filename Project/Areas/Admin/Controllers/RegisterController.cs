using CryptoHelper;
using KanunWebsite.Areas.Admin.ViewModel;
using KanunWebsite.Data;
using KanunWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace KanunWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RegisterController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(VMRegister model)
        {
            if (_context.Users.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError("Email","The email is already in use");
            }
            if (ModelState.IsValid)
            {
                User user = new()
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Password = Crypto.HashPassword(model.Password),
                    Token = Guid.NewGuid().ToString(),
                };
                _context.Users.Add(user);
            }
            return RedirectToAction("index","login");
        }
    }
}
