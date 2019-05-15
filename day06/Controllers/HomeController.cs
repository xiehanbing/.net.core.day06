using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using day06.Filters;
using Microsoft.AspNetCore.Mvc;
using day06.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace day06.Controllers
{
    public class HomeController : BaseController
    {
        [ResouseFilter, ActionFilter, ExceptionFilter]
        [Authorize(AuthenticationSchemes = "cookieSelfName")]
        public IActionResult Index()
        {
            UserModel user = new UserModel()
            {
                Name = "张三",
                Sex = "男"
            };
            var int32 = Convert.ToInt32(user.Name);
            return View(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            return Content("Login");
        }

        public IActionResult DoLogin()
        {
            ClaimsIdentity identity = new ClaimsIdentity("Forms");
            string token = "123456";
            string name = "张三";
            identity.AddClaim(new Claim(ClaimTypes.Sid, token));
            identity.AddClaim(new Claim(ClaimTypes.Name, name));

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync("cookieSelfName", claimsPrincipal);
            return Content("login success");
        }

        public IActionResult LoginOut()
        {
            HttpContext.SignOutAsync("cookieSelfName");
            return Content("loginOut");
        }
        [Authorize(AuthenticationSchemes = "cookieSelfName")]
        public IActionResult Center()
        {
            var token = User.FindFirstValue(ClaimTypes.Sid);

            return Content(token + "Center");
        }
    }
}
