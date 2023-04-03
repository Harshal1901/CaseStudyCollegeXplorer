using CaseStudyClgXplorer.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace CaseStudy4.Controllers
{
    public class DepartmentController : Controller
    {
        LoginDbEntities db1 = new LoginDbEntities();
        // GET: Home
        public ActionResult Index()
        {
            var data = db1.Departments.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department c)
        {
            db1.Departments.Add(c);
            int a = db1.SaveChanges();
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

        public ActionResult Edit(int? id)
        {
            var row = db1.Departments.Where(model => model.DepartmentId == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Department c)
        {
            db1.Entry(c).State = EntityState.Modified;
            int a = db1.SaveChanges();
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
                var datarow = db1.Departments.Where(model => model.DepartmentId == id).FirstOrDefault();
                if (datarow != null)
                {
                    db1.Entry(datarow).State = EntityState.Deleted;
                    int a = db1.SaveChanges();
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