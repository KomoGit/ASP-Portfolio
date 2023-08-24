using KanunWebsite.Data;
using KanunWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KanunWebsite.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            VMContact about = new()
            {
                SiteContactDetails = _context.ContactDetails?.ToList(),
            };
            return View(about);
        }

        public IActionResult Create(VMContact inq)
        {
            Console.WriteLine("McRib Laser Activate!");
            if (ModelState.IsValid)
            {
                if (inq.Inquiry == null)
                {
                    throw new Exception("Inquiry cannot be null!");
                }
                inq.Inquiry.Date = DateTime.Now;
                _context.Inquiries!.Add(inq.Inquiry);
                _context!.SaveChanges();
            }
            return RedirectToAction("index", "contact");
        }
    }
}
