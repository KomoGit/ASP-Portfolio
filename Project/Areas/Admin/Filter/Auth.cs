using CryptoHelper;
using KanunWebsite.Data;
using KanunWebsite.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KanunWebsite.Areas.Admin.Filter
{
    public class Auth:ActionFilterAttribute
    {
        private readonly ApplicationDbContext _context;
        public Auth(ApplicationDbContext context)
        {
            _context = context;
        }
        //Using this system allows others to hijack tokens. Meaning if I use the token of someone else I can login without requiring password or email.
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Cookies.TryGetValue("token", out string token))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "login", controller = "admin" }));
            }
            User user = _context.Users.FirstOrDefault(u =>  u.Token == token);
            if (user == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "login", controller = "admin" }));
            }
            if (context.Controller is Controller controller)
            {
                controller.ViewBag.User = user;
            }
            context.RouteData.Values["loggedUser"] = user;
        }
    }
}
