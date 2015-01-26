using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    public class BaseCommonController : Controller
    {
        protected CommonBs ObjBs;
        public BaseCommonController()
        {
            ObjBs = new CommonBs();
        }
    }
}