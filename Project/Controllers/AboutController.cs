using AngerTravelTours.Data;
using AngerTravelTours.Interfaces;
using AngerTravelTours.ViewModel;
using Microsoft.AspNetCore.Mvc;


namespace AngerTravelTours.Controllers
{
    public class AboutController : Controller, INewsletterCreate
    {
        private readonly AngerDbContext _context;

        public AboutController(AngerDbContext context)
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
            return RedirectToAction("index", "about");
        }

        public IActionResult Index()
        {
            VMAbout model = new()
            {
                Feedbacks = _context.Feedbacks.ToList(),
                Partners = _context.Partners.ToList(),
                RecentPosts = _context.Blogs.OrderBy(o=>o.AddedDate).Take(3).ToList(),
            };
            return View(model);
        }
    }
}
