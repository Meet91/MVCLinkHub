using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ApprovedURLsController : BaseAdminController
    {
        // GET: Admin/ApprovedURLs
        public ActionResult Index(string Status)
        {

            ViewBag.Status = (Status == null ? "P" : Status);
            if(Status==null)
            {
                var urls = ObjBs.urlBs.GetAll().Where(x => x.IsApproved == "P").ToList();
                return View(urls);
            }
            else
            {
                var urls = ObjBs.urlBs.GetAll().Where(x => x.IsApproved == Status).ToList();
                return View(urls);
            }
        }

        public ActionResult Approve(int id)
        {
            try
            {
                var myUrl = ObjBs.urlBs.GetById(id);
                myUrl.IsApproved = "A";
                ObjBs.urlBs.Update(myUrl);
                TempData["msg"] = "Approved Successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Approved Failed: " + ex.Message;
                return RedirectToAction("Index");
            }
        }


        public ActionResult Reject(int id)
        {
            try
            {
                var myUrl = ObjBs.urlBs.GetById(id);
                myUrl.IsApproved = "R";
                ObjBs.urlBs.Update(myUrl);
                TempData["msg"] = "Rejected Successfully.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Reject Failed: " + ex.Message;
                return RedirectToAction("Index");
            }
        }


        //currentstatus is used to return to the same status,for eg.if user is in pending status,then he should redirect to same status.
        [HttpPost]
        public ActionResult ApproveOrRejectAll(List<int> Ids,string Status,string CurrentStatus)
        {
            try
            {
                ObjBs.ApproveOrReject(Ids, Status);
                TempData["msg"] = "Operation Successfull.";
                var urls = ObjBs.urlBs.GetAll().Where(x => x.IsApproved == CurrentStatus).ToList();
                return PartialView("pv_ApprovedUrls", urls);
            }catch(Exception ex)
            {
                TempData["msg"] = "Operation Failed." + ex.Message;
                var urls = ObjBs.urlBs.GetAll().Where(x => x.IsApproved == CurrentStatus).ToList();
                return PartialView("pv_ApprovedUrls", urls);
            }
        }
    }
}