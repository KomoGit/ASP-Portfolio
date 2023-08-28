using AngerTravelTours.Data;
using AngerTravelTours.Interfaces;
using AngerTravelTours.Models;
using AngerTravelTours.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngerTravelTours.Controllers
{
    public class BlogController : Controller, INewsletterCreate
    {
        private readonly AngerDbContext _context;

        public BlogController(AngerDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            List<Blog>? blogs;
            if (id != null)
            {
                blogs = _context.Blogs.Where(b => b.Id == id).ToList();
            }
            else
            {
                blogs = _context.Blogs.ToList();
            }
            VMBlog blog = new()
            {
                Feedbacks = _context.Feedbacks.ToList(),
                Partners = _context.Partners.ToList(),
                Socials = _context.Socials.ToList(),
                Comments = _context.Comments.ToList(),
                RecentPosts = _context.Blogs.OrderByDescending(o => o.AddedDate).Take(3).ToList(),
                Blogs = _context.Blogs.OrderByDescending(o=>o.AddedDate).ToList()
            };
            return View(blog);
        }

        public IActionResult Details(int? id)
        {
            int catId = _context.Blogs.Find(id)!.CategoryId;
            VMBlog blog = new()
            {
                Blogs = _context.Blogs.Include(u => u.User).ToList(),
                Categories = _context.Category.Include(b => b.Blogs).ToList(),
                Feedbacks = _context.Feedbacks.ToList(),
                Partners = _context.Partners.ToList(),
                Socials = _context.Socials.ToList(),
                Comments = _context.Comments.ToList(),
                RelatedPosts = _context.Blogs.OrderBy(o => o.AddedDate).Where(b => b.CategoryId == catId).Take(2).ToList(),
                RecentPosts = _context.Blogs.OrderByDescending(o => o.AddedDate).Take(3).ToList(),        
            };
            return View(blog);
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
            return RedirectToAction("index", "blog");
        }
    }
}
