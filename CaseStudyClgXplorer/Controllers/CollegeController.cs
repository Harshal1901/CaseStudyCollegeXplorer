using CaseStudyClgXplorer.Models;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web.Mvc;

namespace CaseStudy4.Controllers
{
    public class CollegeController : Controller
    {
        LoginDbEntities db = new LoginDbEntities();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Colleges.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(College c)
        {
            db.Colleges.Add(c);
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["InsertMessage"] = "<script>alert('Inserted')</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["InsertMessage"] = "<script>alert('Not Inserted')</script>";
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = db.Colleges.Where(model => model.CollegeId == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(College c)
        {
            db.Entry(c).State = EntityState.Modified;
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["UpdateMessage"] = "<script>alert('Modified')</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["UpdateMessage"] = "<script>alert('Not Modified')</script>";
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var datarow = db.Colleges.Where(model => model.CollegeId == id).FirstOrDefault();
                if (datarow != null)
                {
                    db.Entry(datarow).State = EntityState.Deleted;
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        TempData["DeleteMessage"] = "<script>alert('Deleted')</script>";
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "<script>alert('Not Deleted')</script>";
                    }
                }
            }
            return RedirectToAction("Index");


        }
    }
}