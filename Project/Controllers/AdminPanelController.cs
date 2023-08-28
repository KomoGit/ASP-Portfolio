using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KanunWebsite.Controllers
{
    public class AdminPanelController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
