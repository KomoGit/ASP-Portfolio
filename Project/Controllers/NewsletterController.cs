using KanunWebsite.Data;
using KanunWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace KanunWebsite.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly ApplicationDbContext _context;
        public NewsletterController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(VMBase sub)
        {
            if(ModelState.IsValid)
            {
                if (sub.Subscriber == null)
                {
                    throw new Exception("Subscriber cannot be null!");
                }
                sub.Subscriber.SubscriptionDate = DateTime.Now;
                _context.Subscribers!.Add(sub.Subscriber);
                _context!.SaveChanges();
        
            }
            return RedirectToAction("index", "home");
        }
    }
}
