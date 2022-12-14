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
        public ActionResult Index()
        {
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
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Employee model)
        {
            _context.Employees.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Data Inserted Successfully";
            return View();
        }

    }
}