using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseStudyClgXplorer.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult HomeIndex()
        {
            if (Session["Username"] == null)
            { 
                return RedirectToAction("Login","Users");
            }
            return View();
        }
    }
}