using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    public class BrowseURLController : Controller
    {
        private UrlBs ObjBs;
        public BrowseURLController()
        {
            ObjBs = new UrlBs();
        }

        // GET: Common/BrowseURL
        public ActionResult Index()
        {
            var urls = ObjBs.GetAll();
            return View(urls);
        }
    }
}