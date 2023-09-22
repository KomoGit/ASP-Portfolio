using KanunWebsite.Areas.Admin.Filter;
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
    public class TestimonialController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileManager _fileManager;
        private readonly Testimonial? InsertTestimonial = new();

        public TestimonialController(ApplicationDbContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManager = fileManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            User? usr = ReturnUserData();
            VMAdminTestimonial data = new()
            {
                Fullname = usr.FullName,
                Token = usr.Token,
                Email = usr.Email,
                ProfileImage = usr.ProfilePicture,
                Testimonials = _context.Testimonials.ToList()
            };
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            User? usr = ReturnUserData();
            VMAdminCreateTestimonial data = new()
            {
                Fullname = usr.FullName,
                Token = usr.Token,
                Email = usr.Email,
                ProfileImage = usr.ProfilePicture,
            };
            return View(data);
        }
        [HttpPost]
        public IActionResult Create(VMAdminCreateTestimonial testimonial)
        {
            #region Data binding
            InsertTestimonial.Fullname = testimonial.Name; //Reason why the variable names don't match is because both User and testimonial have Fullname. Had to rename VMTestimonal one to Name.
            InsertTestimonial.Title = testimonial.Title;
            InsertTestimonial.Description = testimonial.Description;
            InsertTestimonial.Image = Upload(testimonial.ImageFile);
            InsertTestimonial.IsHidden = testimonial.IsHidden;
            #endregion
            if (ModelState.IsValid)
            {
                _context.Add(InsertTestimonial);
                _context.SaveChanges();
                return RedirectToAction("index", "testimonial");
            }
            return RedirectToAction("index", "testimonial");
        }
        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        { 
            User? usr = ReturnUserData();
            VMAdminEditTestimonial data = new()
            {
                Fullname = usr.FullName,
                Token = usr.Token,
                Email = usr.Email,
                ProfileImage = usr.ProfilePicture,
                CurrentTestimonialIteration = _context.Testimonials.FirstOrDefault(t => t.Id == id),
            };
            return View(data);
        }

        [HttpPost("{id}")]
        public IActionResult Edit(int id,VMAdminEditTestimonial ViewModel)
        {
            Testimonial? TestimonialModel = _context.Testimonials.FirstOrDefault(b => b.Id == id);
            #region Data Binding
            TestimonialModel.Fullname = ViewModel.Name;
            TestimonialModel.Title = ViewModel.Title;
            TestimonialModel.Description = ViewModel.Description;
            TestimonialModel.IsHidden = ViewModel.IsHidden;
            try
            {
                if(ViewModel.ImageFile != null)
                {
                    _fileManager.Delete(TestimonialModel.Image);
                }          
                TestimonialModel.Image = Upload(ViewModel.ImageFile);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion
            if (ModelState.IsValid)
            {
                _context.SaveChanges();
                return RedirectToAction("index", "testimonial");
            }
            throw new Exception("Model State is not valid.");
        }

        public IActionResult Delete(int id)
        {
            Testimonial? testimonial = _context.Testimonials.FirstOrDefault(t => t.Id == id);
            _context.Testimonials.Remove(testimonial);
            _context.SaveChanges();
            return RedirectToAction("index", "testimonial");
        }

        private User? ReturnUserData()
        {
            return _context.Users.Where(u => u.Token == Request.Cookies["token"]).First();
        }
        private string Upload(IFormFile file)
        {
            if (file == null) throw new Exception("Cannot upload null file");
            return _fileManager.Upload(file);
        }
    }
}
