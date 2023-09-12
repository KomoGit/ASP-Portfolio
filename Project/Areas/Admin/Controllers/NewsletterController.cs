using KanunWebsite.Areas.Admin.Filter;
using KanunWebsite.Areas.Admin.ViewModelAdmin;
using KanunWebsite.Data;
using KanunWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace KanunWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    [TypeFilter(typeof(Auth))]
    public class NewsletterController : Controller
    {
        private readonly ApplicationDbContext _context;
        public NewsletterController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            User? usr = ReturnUserData();
            VMAdminNewsletter newsletter = new()
            {
                Fullname = usr.FullName,
                Token = usr.Token,
                Email = usr.Email,
                ProfileImage = usr.ProfilePicture,
                Subscribers = _context.Subscribers.ToList()
            };
            return View(newsletter);
        }
        public IActionResult Delete(int id)
        {
            NewsletterSubscriber? subscriber = _context.Subscribers.Find(id);
            _context.Subscribers.Remove(subscriber);
            _context.SaveChanges();
            return RedirectToAction("newsletter", "admin");
        }
        private User? ReturnUserData()
        {
            return _context.Users.Where(u => u.Token == Request.Cookies["token"]).FirstOrDefault();
        }
    }
}
