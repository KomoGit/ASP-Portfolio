using AngerTravelTours.Data;
using AngerTravelTours.Interfaces;
using AngerTravelTours.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngerTravelTours.Controllers
{    
    public class BlogDetailController : Controller, INewsletterCreate
    {
        private readonly AngerDbContext _context;
        public BlogDetailController(AngerDbContext context)
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
            return RedirectToAction("index", "blogdetail");
        }

        public IActionResult Index()
        {
            VMHome model = new()
            {
                Feedbacks = _context.Feedbacks.ToList(),
                Galleries = _context.Galleries.ToList(),
                Partners = _context.Partners.ToList(),
                RecentPosts = _context.Blogs.ToList(),
            };
            return View(model);
        }
    }
}
