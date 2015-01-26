using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;


namespace LinkHubUI.Areas.User.Controllers
{
    public class URLController : Controller
    {

        private UrlBs objUrlBs;
        private CategoryBs objCatBs;
        private UserBs objUserBs;

        public URLController()
        {
            objUrlBs = new UrlBs();
            objCatBs = new CategoryBs();
            objUserBs = new UserBs();
        }

        // GET: User/URL
        public ActionResult Index()
        {
            //LinkHubDbEntities db = new LinkHubDbEntities();
            //ViewBag.CategoryId = new SelectList(db.tbl_Category, "CategoryId", "CategoryName");

            ViewBag.CategoryId = new SelectList(objCatBs.GetAll().ToList(), "CategoryId", "CategoryName");
            ViewBag.UserId = new SelectList(objUserBs.GetAll().ToList(), "UserId", "UserEmail");

            return View();
        }


        [HttpPost]
        public ActionResult Create(tbl_Url objUrl)
        {
            //LinkHubDbEntities db = new LinkHubDbEntities();
            //ViewBag.CategoryId = new SelectList(db.tbl_Category, "CategoryId", "CategoryName");

            try
            {
                if(ModelState.IsValid)
                {
                    objUrlBs.Insert(objUrl);
                    TempData["msg"] = "Created Successfully.";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(objCatBs.GetAll().ToList(), "CategoryId", "CategoryName");
                    ViewBag.UserId = new SelectList(objUserBs.GetAll().ToList(), "UserId", "UserEmail");
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Create Failed: " + ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}