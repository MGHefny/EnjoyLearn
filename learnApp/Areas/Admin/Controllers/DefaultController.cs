using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace learnApp.Areas.Admin.Controllers
{
    public class DefaultController : Controller
    {
        //def controller
        // GET: Admin/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}