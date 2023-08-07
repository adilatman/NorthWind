using Microsoft.AspNetCore.Mvc;
using NorthWind.COMMON.ViewModels;
using NorthWind.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.UI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerDAL _cusDal;
        public CustomerController(ICustomerDAL cusDal)
        {
            _cusDal = cusDal;
        }
        public IActionResult Index()
        {
            var customers = _cusDal.CustomerList();
            return View(customers);
        }
        public IActionResult NewCustomer()
        {
            return View(new CustomerVM());
        }
        [HttpPost]
        public IActionResult NewCustomer(CustomerVM customerVM)
        {
            if (_cusDal.AddCustomer(customerVM))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewCustomer");
            }
        }
    }
}
