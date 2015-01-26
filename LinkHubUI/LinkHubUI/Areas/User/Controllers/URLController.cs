using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;


namespace LinkHubUI.Areas.User.Controllers
{
    public class URLController : BaseUserController
    {
        // GET: User/URL
        public ActionResult Index()
        {
            //LinkHubDbEntities db = new LinkHubDbEntities();
            //ViewBag.CategoryId = new SelectList(db.tbl_Category, "CategoryId", "CategoryName");

            ViewBag.CategoryId = new SelectList(ObjBs.categoryBs.GetAll().ToList(), "CategoryId", "CategoryName");
            ViewBag.UserId = new SelectList(ObjBs.urlBs.GetAll().ToList(), "UserId", "UserEmail");

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
                    ObjBs.urlBs.Insert(objUrl);
                    TempData["msg"] = "Created Successfully.";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(ObjBs.categoryBs.GetAll().ToList(), "CategoryId", "CategoryName");
                    ViewBag.UserId = new SelectList(ObjBs.userBs.GetAll().ToList(), "UserId", "UserEmail");
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