using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category

        private CategoryBs objBs;

        public CategoryController()
        {
            objBs = new CategoryBs();
        }

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
                    objBs.Insert(category);
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