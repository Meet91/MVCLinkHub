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
            ViewBag.CategoryId = new SelectList(ObjBs.categoryBs.GetAll().ToList(), "CategoryId", "CategoryName");
            return View();
        }


        [HttpPost]
        public ActionResult Create(tbl_Url objUrl)
        {
            try
            {
                objUrl.IsApproved = "P";
                objUrl.UserId = ObjBs.userBs.GetAll().Where(x => x.UserEmail == User.Identity.Name).FirstOrDefault().UserId;
                if(ModelState.IsValid)
                {
                    ObjBs.urlBs.Insert(objUrl);
                    TempData["msg"] = "Urls Created Successfully.";
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
                TempData["msg"] = "Url Creation Failed: " + ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}