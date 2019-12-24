using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace OAuth.AuthorizationServer.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            var authentication = HttpContext.GetOwinContext().Authentication;
            if (Request.HttpMethod == "POST")
            {
                //用户和密码去数据库验证
                authentication.SignIn(new ClaimsIdentity(new[] {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, Request.Form["username"])
                    }, "Application"));
            }

            return View();
        }

        public ActionResult LoginOut()
        {
            var authentication = HttpContext.GetOwinContext().Authentication;
            authentication.SignOut("Application");

            return View();
        }
    }
}