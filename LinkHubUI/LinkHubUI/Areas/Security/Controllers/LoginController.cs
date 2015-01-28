using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LinkHubUI.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class LoginController : BaseSecurityController
    {
        // GET: Security/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(tbl_User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Membership.ValidateUser(user.UserEmail, user.Password))
                    {
                        FormsAuthentication.SetAuthCookie(user.UserEmail, false);
                        return RedirectToAction("Index", "Home", new { area = "Common" });
                    }
                    else
                    {
                        TempData["msg"] = "Login Failed.";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData["msg"] = "Invalid Username or Password.";
                    return View("Index");
                }
                
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Login Failed: "+ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "Common" });
        }
    }
}