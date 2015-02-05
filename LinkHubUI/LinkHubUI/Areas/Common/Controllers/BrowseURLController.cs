using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;

namespace LinkHubUI.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class BrowseURLController : BaseCommonController
    {
       

        // GET: Common/BrowseURL
        public ActionResult Index(string sortOrder,string sortBy,string Page)
        {
            ViewBag.SortOrder = sortOrder;
            ViewBag.SortBy = sortBy;
            var urls = ObjBs.urlBs.GetAll().Where(x=>x.IsApproved=="A");

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

                default:
                    urls = urls.OrderBy(x => x.UrlTitle).ToList();
                    break;
            }

            //Paging logic
            ViewBag.TotalPages = Math.Ceiling(ObjBs.urlBs.GetAll().Where(x => x.IsApproved == "A").Count() / 10.0);

            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            urls=urls.Skip((page-1)*10).Take(10);

            return View(urls);
        }

        public FileResult ExportTo(string ReportType)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/UrlReport.rdlc");

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "UrlDataSet";
            reportDataSource.Value = ObjBs.urlBs.GetAll().Where(x => x.IsApproved == "A").ToList();

            localReport.DataSources.Add(reportDataSource);

            string reportType = ReportType;
            string mimeType;
            string encoding;
            string fileNameExtension = (ReportType == "Excel") ? "xsls" :(ReportType=="Word"? "doc" :"pdf");
            Warning[] warning;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = localReport.Render(reportType, "", out mimeType, out encoding, out fileNameExtension, out streams, out warning);
            Response.AddHeader("content-disposition","attachment;filename=Urls."+fileNameExtension);

            return File(renderedBytes, fileNameExtension);
        }
    }
}