using KanunWebsite.Data;
using KanunWebsite.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KanunWebsite.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            VMBlog blog = new()
            {
                Blogs = _context.Blogs?.OrderByDescending(o => o.PublishDate).ToList(),
                SiteContactDetails = _context.ContactDetails?.ToList(),
                Users = _context.Users?.OrderBy(u => u.FullName).Take(4).ToList(),
                Titles = _context.Titles?.ToList(),
            };
            return View(blog);
        }
    }
}
