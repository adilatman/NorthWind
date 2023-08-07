using Microsoft.AspNetCore.Mvc;
using NorthWind.COMMON.ViewModels;
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
            if (_supDal.AddSupplier(SupplierVM))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewSupplier");
            }
        }
    }
}
