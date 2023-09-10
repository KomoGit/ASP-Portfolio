using KanunWebsite.Areas.Admin.Filter;
using KanunWebsite.Areas.Admin.ViewModelAdmin;
using KanunWebsite.Data;
using KanunWebsite.Models;
using KanunWebsite.Models.Blog;
using Microsoft.AspNetCore.Mvc;

namespace KanunWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    [TypeFilter(typeof(Auth))]
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            User? usr = ReturnUserData();
            VMAdminBlog dashboard = new()
            {
                Fullname = usr.FullName,
                Token = usr.Token,
                Email = usr.Email,
                ProfileImage = usr.ProfilePicture,
                Blogs = _context.Blogs?.Where(b => !b.IsHidden && b.Publisher.Token == usr.Token).OrderByDescending(b => b.PublishDate).ToList(),
                Categories = _context.Categories?.ToList(),
            };
            return View(dashboard);
        }

        //[HttpPut("id")]
        public IActionResult Edit(int id)
        {
            throw new NotImplementedException();
        }

        public IActionResult Delete(int id)
        {
            Blog? blog = _context.Blogs.Find(id);
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
            return RedirectToAction("blog", "admin");
        }

        private User? ReturnUserData()
        {
            return _context.Users.Where(u => u.Token == Request.Cookies["token"]).First();
        }
    }
}
