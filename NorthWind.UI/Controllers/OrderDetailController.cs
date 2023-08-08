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
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailDAL _oddDal;
        private readonly IOrderDAL _ordDal;
        private readonly IProductDAL _proDal;
        public OrderDetailController(IOrderDetailDAL oddDal, IOrderDAL ordDal, IProductDAL proDal)
        {
            _oddDal = oddDal;
            _ordDal = ordDal;
            _proDal = proDal;
        }
        public IActionResult Index()
        {
            var orderDetails = _oddDal.OrderDetailTable();
            return View(orderDetails);
        }
        public IActionResult NewOrderDetail()
        {
            return View(new AddOrderDetailVM()
            {
                DropDownOrders = _ordDal.DropDownOrders(),
                DropDownProducts = _proDal.DropDownProducts(),
                orderVMs = _ordDal.GetOrders(),
                productVMs = _proDal.GetProducts()
            });
        }
        [HttpPost]
        public IActionResult NewOrderDetail(AddOrderDetailVM addOrderDetailVM)
        {
            TempData["SuccessMessageOrderDetailAdd"] = null;
            TempData["ErrorMessageOrderDetailAdd"] = null;
            if (_oddDal.AddOrderDetail(addOrderDetailVM))
            {
                TempData["SuccessMessageOrderDetailAdd"] = "Order Detail added successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessageOrderDetailAdd"] = "Error adding order detail.";
                return View("NewOrderDetail");
            }
        }
    }
}
