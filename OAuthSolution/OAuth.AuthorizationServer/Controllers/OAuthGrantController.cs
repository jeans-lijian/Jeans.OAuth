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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GrantAdd(Credentials model)
        {
            if (model==null)
            {
                return RedirectToAction("GrantList");
            }

            model.Id = Guid.NewGuid();
            _credentialService.AddCredentials(model);

            return RedirectToAction("GrantList");
        }

        public ActionResult GrantEdit(Guid id)
        {
            Credentials entity = _credentialService.GetCredentialsById(id);
            if (entity==null)
            {
                return View("Error");
            }

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GrantEdit(Credentials model)
        {
            if (model==null)
            {
                return RedirectToAction("GrantList");
            }

            Credentials entity= _credentialService.GetCredentialsById(model.Id);
            if (entity!=null)
            {
                entity.ClientId = model.ClientId;
                entity.ClientSecret = model.ClientSecret;
                entity.RedirectUri = model.RedirectUri;

                _credentialService.UpdateCredentials(entity);
            }

            return RedirectToAction("GrantList");
        }

        public ActionResult GrantDelete(Guid id)
        {
            Credentials entity = _credentialService.GetCredentialsById(id);
            if (entity == null)
            {
                return View("Error");
            }

            _credentialService.DeleteCredentials(entity);

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserAdd(UserEntity model)
        {
            if (model == null)
            {
                return RedirectToAction("UserList");
            }

            model.Id = Guid.NewGuid();
            _userService.AddUser(model);

            return RedirectToAction("UserList");
        }

        public ActionResult UserEdit(Guid id)
        {
            UserEntity entity = _userService.GetUserById(id);
            if (entity == null)
            {
                return View("Error");
            }

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserEdit(UserEntity model)
        {
            if (model == null)
            {
                return RedirectToAction("UserList");
            }

            UserEntity entity = _userService.GetUserById(model.Id);
            if (entity != null)
            {
                entity.UserName = model.UserName;
                entity.Password = model.Password;

                _userService.UpdateUser(entity);
            }
            
            return RedirectToAction("UserList");
        }

        public ActionResult UserDelete(Guid id)
        {
            UserEntity entity = _userService.GetUserById(id);
            if (entity == null)
            {
                return View("Error");
            }

            _userService.DeleteUser(entity);

            return RedirectToAction("UserList");
        }

        #endregion

    }
}