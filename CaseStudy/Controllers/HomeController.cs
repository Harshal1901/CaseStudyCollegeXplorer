using CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseStudy.Controllers
{
    public class HomeController : Controller
    {
        LoginContext db = new LoginContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(tblLogin login)
        {
            
            if (ModelState.IsValid)
            {
                db.tblLogins.Add(login);
                db.SaveChanges();
            }
            return View();
        }
    }
}