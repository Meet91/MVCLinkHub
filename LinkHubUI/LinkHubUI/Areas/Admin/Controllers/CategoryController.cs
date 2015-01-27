using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class CategoryController : BaseAdminController
    {
        // GET: Admin/Category

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ObjBs.categoryBs.Insert(category);
                    TempData["msg"] = "Created Sucessfully.";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Index");
                }
                
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Create Failed: "+ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}