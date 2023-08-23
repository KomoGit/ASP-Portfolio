using KanunWebsite.Data;
using KanunWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KanunWebsite.Controllers
{
    public class CaseStudies : Controller
    {
        private readonly ApplicationDbContext _context;

        public CaseStudies(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            VMCaseStudy caseStudy = new()
            {

            };
            return View(caseStudy);
        }
    }
}
