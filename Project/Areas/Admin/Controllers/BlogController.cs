using KanunWebsite.Areas.Admin.Filter;
using KanunWebsite.Areas.Admin.ViewModelAdmin;
using KanunWebsite.Data;
using KanunWebsite.Models;
using KanunWebsite.Models.Blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KanunWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/[controller]/[action]")]
    [TypeFilter(typeof(Auth))]
    public class BlogController : Controller
    {
        private Blog insertBlog = new Blog();
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
        [HttpGet]
        public IActionResult Create()
        {
            User? usr = ReturnUserData();
            VMAdminCreateBlog data = new()
            {
                Fullname = usr.FullName,
                Token = usr.Token,
                Email = usr.Email,
                ProfileImage = usr.ProfilePicture,
                Categories = _context.Categories.ToList(),
            };
            return View(data);
        }
        [HttpPost]
        public IActionResult Create(VMAdminCreateBlog blog)
        {
            insertBlog.Title = blog.Title;
            insertBlog.Description = blog.Description;
            insertBlog.BodyText = blog.BodyText;
            insertBlog.PublishDate = blog.PublishDate;
            insertBlog.UserId = ReturnUserData().Id;
            insertBlog.CategoryId = blog.CategoryId;
            insertBlog.PreviewImage = "XD";
            insertBlog.FullImage = "LOL";
            if (ModelState.IsValid)
            {
                _context.Blogs.Add(insertBlog);
                _context.SaveChanges();
                return RedirectToAction("dashboard", "admin");
            }
            return View(blog);
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
            return RedirectToAction("index", "blog");
        }

        private User? ReturnUserData()
        {
            return _context.Users.Where(u => u.Token == Request.Cookies["token"]).First();
        }

        private List<SelectListItem> CategoryList()
        {
            return _context.Categories.Select(
            c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
        }
    }
}
