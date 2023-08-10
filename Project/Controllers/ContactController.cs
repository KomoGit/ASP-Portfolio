using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    public class ContactController : Controller
    {
        private readonly SEOTechDbContext _context;
        public ContactController(SEOTechDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var partialViewModel = new PartialViewResult();
            return View(partialViewModel);
        }
        [HttpGet]
        public IActionResult Create(SiteInformation info)
        {
            if (ModelState.IsValid)
            {
                _context.SiteInformation.Add(info);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(info);
        }
    }
}
