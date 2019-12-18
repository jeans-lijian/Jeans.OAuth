using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jeans.OAuth.Core.Domains;
using Jeans.OAuth.Server;

namespace OAuth.AuthorizationServer.Controllers
{
    /// <summary>
    /// oauth 授权clientid clientsercet url 等配置
    /// user
    /// </summary>
    public class OAuthGrantController : Controller
    {
        private readonly ICredentialServer _credentialService;
        private readonly IUserServer _userService;
        public OAuthGrantController(
            ICredentialServer credentialService,
            IUserServer userService)
        {
            _credentialService = credentialService;
            _userService = userService;
        }

        #region OAuthGrant

        public ActionResult GrantList()
        {
            List<Credentials> credentials = _credentialService.GetCredentials();
            return View(credentials);
        }

        public ActionResult GrantAdd()
        {
            return View();
        }

        public ActionResult GrantEdit()
        {
            return View();
        }

        public ActionResult GrantDelete()
        {
            return View("GrantList");
        }

        #endregion


        #region User

        public ActionResult UserList()
        {
            List<UserEntity> userEntities = _userService.GetUsers();
            return View(userEntities);
        }

        public ActionResult UserAdd()
        {
            return View();
        }

        public ActionResult UserEdit()
        {
            return View();
        }

        public ActionResult UserDelete()
        {
            return View("UserList");
        } 

        #endregion

    }
}