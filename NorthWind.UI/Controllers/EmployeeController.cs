using Microsoft.AspNetCore.Mvc;
using NorthWind.COMMON.ViewModels;
using NorthWind.COMMON.ViewModels.AddVM;
using NorthWind.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeDAL _empDal;
        public EmployeeController(IEmployeeDAL empDal)
        {
            _empDal = empDal;
        }
        public IActionResult Index()
        {
            var employees = _empDal.EmployeeTable();
            return View(employees);
        }
        public IActionResult NewEmployee()
        {
            return View(new AddEmployeeVM()
            {
                DropDownReportsTo = _empDal.DropDownEmployees(),
                employeeVMs = _empDal.GetEmployees()
            });
        }
        [HttpPost]
        public IActionResult NewEmployee(AddEmployeeVM addEmployeeVM)
        {
            TempData["SuccessMessageOrderAdd"] = null;
            TempData["ErrorMessageOrderAdd"] = null;
            if (_empDal.AddEmployee(addEmployeeVM))
            {
                TempData["SuccessMessageEmployeeAdd"] = "Employee added successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessageEmployeeAdd"] = "Error adding employee.";
                return View("NewEmployee");
            }
        }
    }
}
