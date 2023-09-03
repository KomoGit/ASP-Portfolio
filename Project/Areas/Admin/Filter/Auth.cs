﻿using KanunWebsite.Data;
using KanunWebsite.Models;
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

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.HttpContext.Request.Cookies.TryGetValue("token", out string token))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "index",controller = "login" }));
            }
            User user = _context.Users.FirstOrDefault(u => u.Token == token);
            if (user == null)
            {
                new RedirectToRouteResult(new RouteValueDictionary(new { action = "index", controller = "login" }));
            }
            if (context.Controller is Controller controller)
            {
                controller.ViewBag.User = user;
            }
            context.RouteData.Values["loggedUser"] = user;
        }
    }
}
