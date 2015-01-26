using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    public class ListUserController : Controller
    {
        private UserBs ObjBs;

        public ListUserController()
        {
            ObjBs = new UserBs();
        }

        // GET: Admin/ListUser
        public ActionResult Index(string sortOrder, string sortBy, string Page)
        {
            ViewBag.SortOrder = sortOrder;
            ViewBag.SortBy = sortBy;
            var users = ObjBs.GetAll();

            switch (sortBy)
            {
                case "UserEmail":
                    switch (sortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.UserEmail).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.UserEmail).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "Role":
                    switch (sortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.Role).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.Role).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    users = users.OrderBy(x => x.UserEmail).ToList();
                    break;
            }

            //Paging logic
            ViewBag.TotalPages = Math.Ceiling(ObjBs.GetAll().Count() / 10.0);

            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            users = users.Skip((page - 1) * 10).Take(10);

            return View(users);
        }
    }
}