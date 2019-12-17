using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OAuth.AuthorizationServer.Controllers
{
    /// <summary>
    /// oauth 授权clientid clientsercet url 等配置
    /// </summary>
    public class OAuthGrantController : Controller
    {
        // GET: OAuthGrant
        public ActionResult List()
        {
            return View();
        }
    }
}