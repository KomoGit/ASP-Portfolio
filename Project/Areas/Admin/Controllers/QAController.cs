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
        private readonly FAQ QAInsert = new();
        private readonly ApplicationDbContext _context;
        public QAController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            User? usr = ReturnUserData();
            VMAdminQA data = new()
            {
                Fullname = usr.FullName,
                Token = usr.Token,
                Email = usr.Email,
                ProfileImage = usr.ProfilePicture,
                Questions = _context.FAQs.ToList(),
            };
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            User? usr = ReturnUserData();
            VMAdminCreateQA data = new()
            {
                Fullname = usr.FullName,
                Token = usr.Token,
                Email = usr.Email,
                ProfileImage = usr.ProfilePicture,
            };
            return View(data);  
        }

        [HttpPost]
        public IActionResult Create(VMAdminCreateQA qa)
        {
            #region Data Binding
            QAInsert.CardId = qa.CardId;
            QAInsert.Question = qa.Question;
            QAInsert.Answer = qa.Answer;
            QAInsert.IsHidden = qa.IsHidden;
            #endregion
            if (ModelState.IsValid)
            {
                _context.Add(QAInsert);
                _context.SaveChanges();
                return RedirectToAction("index", "qa");
            }
            throw new Exception("Model State Is Not Valid");
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            FAQ? CurrentIteration = _context.FAQs.FirstOrDefault(f => f.Id == id);
            User? usr = ReturnUserData();
            VMAdminEditQA data = new()
            {
                Fullname = usr.FullName,
                Token = usr.Token,
                Email = usr.Email,
                ProfileImage = usr.ProfilePicture,
            };
            ViewBag.FAQ = CurrentIteration;
            return View(data);
        }

        [HttpPost("{id}")]
        public IActionResult Edit(int id, VMAdminEditQA ViewModel)
        {
            FAQ? QAModel = _context.FAQs.FirstOrDefault(f => f.Id == id);
            #region Data Binding
            QAModel.CardId = ViewModel.CardId;
            QAModel.Question = ViewModel.Question;
            QAModel.Answer = ViewModel.Answer;
            QAModel.IsHidden = ViewModel.IsHidden;
            #endregion
            if (ModelState.IsValid)
            {
                _context.SaveChanges();
                return RedirectToAction("index", "qa");
            }
            throw new Exception("Model State is not valid.");
        }

        public IActionResult Delete(int id)
        {
            FAQ? QA = _context.FAQs.FirstOrDefault(f => f.Id == id);
            _context.FAQs.Remove(QA);
            _context.SaveChanges();
            return RedirectToAction("index", "qa");
        }

        private User? ReturnUserData()
        {
            return _context.Users.Where(u => u.Token == Request.Cookies["token"]).FirstOrDefault();
        }
    }
}
