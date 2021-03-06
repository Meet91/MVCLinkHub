﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ListCategoryController : BaseAdminController
    {
      
        // GET: Admin/ListCategory
        public ActionResult Index(string sortOrder, string sortBy, string Page)
        {
            ViewBag.SortOrder = sortOrder;
            ViewBag.SortBy = sortBy;
            var categories = ObjBs.categoryBs.GetAll();

            switch (sortBy)
            {
                case "CategoryName":
                    switch (sortOrder)
                    {
                        case "Asc":
                            categories = categories.OrderBy(x => x.CategoryName).ToList();
                            break;
                        case "Desc":
                            categories = categories.OrderByDescending(x => x.CategoryName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "CategoryDesc":
                    switch (sortOrder)
                    {
                        case "Asc":
                            categories = categories.OrderBy(x => x.CategoryDesc).ToList();
                            break;
                        case "Desc":
                            categories = categories.OrderByDescending(x => x.CategoryDesc).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    categories = categories.OrderBy(x => x.CategoryName).ToList();
                    break;
            }

            //Paging logic
            ViewBag.TotalPages = Math.Ceiling(ObjBs.categoryBs.GetAll().Count() / 10.0);

            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            categories = categories.Skip((page - 1) * 10).Take(10);

            return View(categories);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                ObjBs.categoryBs.Delete(id);
                TempData["msg"]="Deleted Successfully.";
                return RedirectToAction("Index");
            }catch(Exception ex){
                TempData["msg"] = "Delete Failed. " + ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}