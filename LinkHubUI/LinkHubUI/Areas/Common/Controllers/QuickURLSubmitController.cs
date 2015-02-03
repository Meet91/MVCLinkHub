using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class QuickURLSubmitController : BaseCommonController
    {
        // GET: Common/QuickURLSubmit
        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(ObjBs.categoryBs.GetAll().ToList(), "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(QuickURLSubmitModel MyQuickUrl )
        {
            try
            {
                
                ModelState.Remove("myUser.Password");
                ModelState.Remove("myUser.ConfirmPassword");
                ModelState.Remove("myUrl.UrlDesc");

                if(ModelState.IsValid)
                {
                    ObjBs.InsertQuickURL(MyQuickUrl);
                    TempData["msg"] = "Created Successfully.";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(ObjBs.categoryBs.GetAll().ToList(), "CategoryId", "CategoryName");
                    return View();
                }
            }catch(Exception ex)
            {
                TempData["msg"] = "Create Failed :"+ex.Message;
                return RedirectToAction("Index");
            }

        }
    }
}