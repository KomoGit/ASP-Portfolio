using KanunWebsite.Areas.Admin.Filter;
using KanunWebsite.Areas.Admin.Libraries;
using KanunWebsite.Areas.Admin.Libraries.Repository;
using KanunWebsite.Areas.Admin.ViewModelAdmin;
using KanunWebsite.Data;
using KanunWebsite.Models;
using KanunWebsite.Models.Blog;
using Microsoft.AspNetCore.Mvc;

namespace KanunWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/[controller]/[action]")]
    [TypeFilter(typeof(Auth))]
    public class BlogController : Controller
    {
        private readonly Blog InsertBlog = new();
        private readonly ApplicationDbContext _context;
        private readonly IFileManager _fileManager;
        public BlogController(ApplicationDbContext context,IFileManager fileManager)
        {
            _fileManager = fileManager;
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
                Blogs = _context.Blogs?.Where(b => b.Publisher.Token == usr.Token).OrderByDescending(b => b.PublishDate).ToList(),
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
            InsertBlog.Title = blog.Title;
            InsertBlog.Description = blog.Description;
            InsertBlog.BodyText = blog.BodyText;
            InsertBlog.PublishDate = blog.PublishDate;
            InsertBlog.UserId = ReturnUserData().Id;
            InsertBlog.CategoryId = blog.CategoryId;
            InsertBlog.PreviewImage = Upload(blog.PreviewImageFile);
            InsertBlog.FullImage = Upload(blog.FullImageFile);
            InsertBlog.IsHidden = blog.IsHidden;
            if (ModelState.IsValid)
            {
                _context.Blogs.Add(InsertBlog);
                _context.SaveChanges();
                return RedirectToAction("index", "blog");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit()
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

        [HttpPut("id")]
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

        private string Upload(IFormFile file) 
        {
            if (file == null) throw new Exception("Cannot upload null file");
            return _fileManager.Upload(file);
        }

        private User? ReturnUserData()
        {
            return _context.Users.Where(u => u.Token == Request.Cookies["token"]).First();
        }
    }
}
