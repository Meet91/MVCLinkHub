﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    public class BrowseURLController : Controller
    {
        private UrlBs ObjBs;
        public BrowseURLController()
        {
            ObjBs = new UrlBs();
        }

        // GET: Common/BrowseURL
        public ActionResult Index(string sortOrder,string sortBy)
        {
            ViewBag.SortOrder = sortOrder;
            ViewBag.SortBy = sortBy;
            var urls = ObjBs.GetAll().Where(x=>x.IsApproved=="A");

            switch(sortBy)
            {
                case "Title":
                    switch (sortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.UrlTitle).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.UrlTitle).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "Url":
                    switch (sortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.Url).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.Url).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "UrlDesc":
                    switch (sortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.UrlDesc).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.UrlDesc).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "Category":
                    switch (sortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.tbl_Category.CategoryName).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.tbl_Category.CategoryName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    urls = urls.OrderBy(x => x.UrlTitle).ToList();
                    break;


            }

            /*switch (sortOrder)
            {
                case "Asc":
                    urls = urls.OrderBy(x => x.UrlTitle).ToList();
                    break;
                case "Desc":
                    urls = urls.OrderByDescending(x => x.UrlTitle).ToList();
                    break;
                default:
                    break;
            }*/
            return View(urls);
        }
    }
}