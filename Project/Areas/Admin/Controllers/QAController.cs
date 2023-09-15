using KanunWebsite.Areas.Admin.Filter;
using KanunWebsite.Areas.Admin.ViewModelAdmin;
using KanunWebsite.Data;
using KanunWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace KanunWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/[controller]/[action]")]
    [TypeFilter(typeof(Auth))]
    public class QAController : Controller
    {
        private readonly ApplicationDbContext _context;
        public QAController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            User? usr = ReturnUserData();
            VMAdminQA newsletter = new()
            {
                Fullname = usr.FullName,
                Token = usr.Token,
                Email = usr.Email,
                ProfileImage = usr.ProfilePicture,
                Questions = _context.FAQs.ToList(), 
            };
            return View(newsletter);
        }

        [HttpPost]
        public IActionResult Create()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IActionResult Edit()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return View();
        }
        private User? ReturnUserData()
        {
            return _context.Users.Where(u => u.Token == Request.Cookies["token"]).FirstOrDefault();
        }
    }
}
