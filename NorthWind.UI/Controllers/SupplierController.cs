using Microsoft.AspNetCore.Mvc;
using NorthWind.COMMON.ViewModels;
using NorthWind.COMMON.ViewModels.EntityVM;
using NorthWind.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.UI.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierDAL _supDal;
        public SupplierController(ISupplierDAL supDal)
        {
            _supDal = supDal;
        }
        public IActionResult Index()
        {
            var suppliers = _supDal.SupplierList();
            return View(suppliers);
        }
        public IActionResult NewSupplier()
        {
            return View(new SupplierVM());
        }
        [HttpPost]
        public IActionResult NewSupplier(SupplierVM SupplierVM)
        {
            TempData["SuccessMessageSupplierAdd"] = null;
            TempData["ErrorMessageSupplierAdd"] = null;
            if (_supDal.AddSupplier(SupplierVM))
            {
                TempData["SuccessMessageSupplierAdd"] = "Supplier added successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessageSupplierAdd"] = "Error adding supplier.";
                return View("NewSupplier");
            }
        }
    }
}
