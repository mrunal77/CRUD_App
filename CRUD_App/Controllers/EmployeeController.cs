using Employee_CRUD_App.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Employee_CRUD_App.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // GET: Employee
        public ActionResult GetData()
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                List<Employee> employeeList = db.Employees.ToList<Employee>();
                if (employeeList != null)
                {
                    return Json(new { data = employeeList },
                    JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { data = new List<Employee>() },
                    JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult StoreOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Employee());
            else
            {
                using (EmployeeContext db = new EmployeeContext())
                {
                    return View(db.Employees.Where(x => x.Id == id).FirstOrDefault<Employee>());
                }
            }
        }

        [HttpPost]
        public ActionResult StoreOrEdit(Employee employeeob)
        {
            if (ModelState.IsValid)
            {
                using (EmployeeContext db = new EmployeeContext())
                {
                    if (employeeob.Id == 0)
                    {
                        db.Employees.Add(employeeob);
                        db.SaveChanges();
                        return Json(new { success = true, message = "Saved Successfully", JsonRequestBehavior.AllowGet });
                    }
                    else
                    {
                        db.Entry(employeeob).State = EntityState.Modified;
                        db.SaveChanges();
                        return Json(new { success = true, message = "Updated Successfully", JsonRequestBehavior.AllowGet });
                    }
                }
            }
            return Json(new { success = false, message = "Insertion Failed", JsonRequestBehavior.AllowGet });

        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                Employee emp = db.Employees.Where(x => x.Id == id).FirstOrDefault<Employee>();
                db.Employees.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully", JsonRequestBehavior.AllowGet });
            }
        }

    }
}