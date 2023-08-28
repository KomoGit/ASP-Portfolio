using Microsoft.AspNetCore.Mvc;

namespace KanunWebsite.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Auth()
        {
            return View();
        }
    }
}
