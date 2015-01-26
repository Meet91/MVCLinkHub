using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    public class ListCategoryController : Controller
    {
        private CategoryBs ObjBs;

        public ListCategoryController()
        {
            ObjBs = new CategoryBs();
        }

        // GET: Admin/ListCategory
        public ActionResult Index(string sortOrder, string sortBy, string Page)
        {
            ViewBag.SortOrder = sortOrder;
            ViewBag.SortBy = sortBy;
            var categories = ObjBs.GetAll();

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
            ViewBag.TotalPages = Math.Ceiling(ObjBs.GetAll().Count() / 10.0);

            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            categories = categories.Skip((page - 1) * 10).Take(10);

            return View(categories);
        }
    }
}