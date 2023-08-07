using Microsoft.AspNetCore.Mvc;
using NorthWind.COMMON.ViewModels;
using NorthWind.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.UI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderDAL _ordDal;
        private readonly ICustomerDAL _cusDal;
        private readonly IEmployeeDAL _empDal;
        private readonly IShipperDAL _shiDal;
        public OrderController(IOrderDAL ordDal, ICustomerDAL cusDal, IEmployeeDAL empDal, IShipperDAL shiDal)
        {
            _ordDal = ordDal;
            _cusDal = cusDal;
            _empDal = empDal;
            _shiDal = shiDal;
        }
        public IActionResult Index()
        {
            var orders = _ordDal.OrderTable();
            return View(orders);
        }
        public IActionResult NewOrder()
        {
            return View(new AddOrderVM()
            {
                DropDownCustomers = _cusDal.DropDownCustomers(),
                DropDownEmployees=_empDal.DropDownEmployees(),
                DropDownShippers=_shiDal.DropDownShippers(),
                customerVMs=_cusDal.GetCustomers(),
                employeeVMs = _empDal.GetEmployees(),
                shipperVMs=_shiDal.GetShippers()
            });
        }
        [HttpPost]
        public IActionResult NewOrder(AddOrderVM addOrderVM)
        {
            if (_ordDal.AddOrder(addOrderVM))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewOrder");
            }
        }
    }
}
