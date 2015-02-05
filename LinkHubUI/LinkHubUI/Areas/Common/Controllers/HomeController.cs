using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseCommonController
    {
        // GET: Common/Home
        public ActionResult Index()
        {
            TempData["msg"] = "Admin Username:- admin@gmail.com &" + " Admin Password:- admin*****" + "*****User Username:- user@gmail.com &" + " User Password:- user";
            return View();
        }
    }
}