using AngerTravelTours.Data;
using AngerTravelTours.Interfaces;
using AngerTravelTours.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AngerTravelTours.Controllers
{
    public class PackageController : Controller, INewsletterCreate
    {
        private readonly AngerDbContext _context;
        public PackageController(AngerDbContext context)
        {
            _context=context;
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
            return RedirectToAction("index", "package");
        }

        public IActionResult Index()
        {
            VMPackage package = new()
            {
                RecentPosts = _context.Blogs.OrderBy(o => o.AddedDate).Take(3).ToList(),
                Packages = _context.TourPackages.ToList(),
                Feedbacks = _context.Feedbacks.ToList(),
                Partners = _context.Partners.ToList(),
            };
            return View(package);
        }
    }
}
