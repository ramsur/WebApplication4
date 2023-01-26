using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDBContext1 _context = new EmployeeDBContext1();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ActionResult Index()
        {
            log.Debug("Inside Index");
            var listofdata = _context.Employees.ToList();
            
            return View(listofdata);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee model) 
        {
            _context.Employees.Add(model);  
            _context.SaveChanges();
            ViewBag.Message = "Data Inserted Successfully";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Employee model)
        {
            var data = _context.Employees.Where(x => x.EmployeeID == model.EmployeeID).FirstOrDefault();
            if (data != null)
            {
                data.Location = model.Location; 
                data.LastName = model.LastName; 
                data.FirstName = model.FirstName;
                data.Department = model.Department;
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }


        public ActionResult Detail(int id)
        {
            var data = _context.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int id) 
        {
            var data = _context.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();
            _context.Employees.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Record Deleted Successfully";
            return RedirectToAction("index");
        }
    }
}