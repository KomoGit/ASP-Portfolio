using KanunWebsite.Areas.Admin.Filter;
using KanunWebsite.Areas.Admin.ViewModelAdmin;
using KanunWebsite.Data;
using KanunWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KanunWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    [TypeFilter(typeof(Auth))]
    public class LeadController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LeadController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            User? usr = ReturnUserData();
            VMAdminLead lead = new()
            {
                Fullname = usr.FullName,
                Token = usr.Token,
                Email = usr.Email,
                ProfileImage = usr.ProfilePicture,
                Leads = _context.Inquiries.ToList()
            };
            return View(lead);
        }
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
        private User? ReturnUserData()
        {
            return _context.Users.Where(u => u.Token == Request.Cookies["token"]).FirstOrDefault();
        }
    }
}
