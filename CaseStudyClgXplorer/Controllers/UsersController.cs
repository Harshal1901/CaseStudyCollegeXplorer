using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaseStudyClgXplorer.Models;

namespace CaseStudyClgXplorer.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users

         private DataContext db = new DataContext();
       

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register() 
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(User usr) 
        {
            if (ModelState.IsValid)
            {
               db.Users.Add(usr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("","Some Error Occured");
            }
            return View(usr);
        }




        public ActionResult Login()
        {
            return View();
        
        }
        [HttpPost]
        public ActionResult Login(User s)
        {

            var credentials = db.Users.FirstOrDefault(model => model.Username == s.Username && model.Password == s.Password);
            int a = 10;
            if (credentials == null)

            {
                ViewBag.ErrorMessage = "Login Failed";
                return View();
            }
            else
            {
                Session["Username"] = s.Username;
                return RedirectToAction("HomeIndex", "Home");
            }


            return View();
        }
     
       
        
    }
}