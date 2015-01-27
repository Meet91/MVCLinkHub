using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.User.Controllers
{
    public class BaseUserController : Controller
    {
        protected UserAreaBs ObjBs;

        public BaseUserController()
        {
            ObjBs = new UserAreaBs();
        }

       
    }
}