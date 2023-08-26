using Microsoft.AspNetCore.Mvc;

namespace KanunWebsite.Controllers
{
    public class AdminPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
