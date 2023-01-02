using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayrollAppMVC.Controllers
{
    public class EmpController : Controller
    {
        IEmployeeBL employeeBL;
        public EmpController(IEmployeeBL employeeBL)
        {
            this.employeeBL = employeeBL;
        }
        public IActionResult Index()
        {
            List<EmployeeModel> lstEmployee = new List<EmployeeModel>();
            lstEmployee = employeeBL.GetAllEmployees().ToList();
            return View(lstEmployee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] EmployeeModel emp)
        {
            if (ModelState.IsValid) {
                employeeBL.AddEmployee(emp);
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        [HttpGet]
        public IActionResult DeleteEmployee(int? id)
        {
            if (id == null) {
                return NotFound();
            }
            EmployeeModel emp = employeeBL.GetEmployeeData(id);

            if (emp == null) {
                return NotFound();
            }
            return View(emp);
        }

        [HttpPost, ActionName("DeleteEmployee")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            employeeBL.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateEmployee(int? id)
        {
            if (id == null) {
                return NotFound();
            }
            EmployeeModel emp = employeeBL.GetEmployeeData(id);

            if (emp == null) {
                return NotFound();
            }
            return View(emp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateEmployee(int id, [Bind] EmployeeModel emp)
        {
            if (id != emp.EmpId) {
                return NotFound();
            }
            if (ModelState.IsValid) {
                employeeBL.UpdateEmployee(emp);
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null) {
                return NotFound();
            }
            EmployeeModel employee = employeeBL.GetEmployeeData(id);

            if (employee == null) {
                return NotFound();
            }
            return View(employee);
        }

    }
}
