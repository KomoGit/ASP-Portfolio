using AngerTravelTours.Data;
using AngerTravelTours.Interfaces;
using AngerTravelTours.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AngerTravelTours.Controllers
{
    public class ContactController : Controller, INewsletterCreate
    {
        private readonly AngerDbContext _context;

        public ContactController(AngerDbContext context)
        {
            _context = context;
        }

        public IActionResult Create(VMBase sub)
        {
            if (ModelState.IsValid)
            {
                if (sub.Subscriber == null)
                {
                    throw new Exception("Subscriber cannot be null!");
                }
                sub.Subscriber.AddedDate = DateTime.Now;
                _context.Subscribes.Add(sub.Subscriber);
                _context.SaveChanges();
            }
            return RedirectToAction("index", "contact");
        }

        public IActionResult Index()
        {
            VMContact contact = new()
            {
                Feedbacks = _context.Feedbacks.ToList(),
                Contacts = _context.Contacts.ToList(),
                Partners = _context.Partners.ToList(),
                RecentPosts = _context.Blogs.OrderBy(o => o.AddedDate).Take(3).ToList()
            };
            return View(contact);
        }
    }
}
