using Microsoft.AspNetCore.Mvc;
using NorthWind.COMMON.ViewModels;
using NorthWind.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.UI.Controllers
{
    public class ShipperController : Controller
    {
        private readonly IShipperDAL _shiDal;
        public ShipperController(IShipperDAL shiDal)
        {
            _shiDal = shiDal;
        }
        public IActionResult Index()
        {
            var shippers = _shiDal.GetShippers();
            return View(shippers);
        }
        public IActionResult NewShipper()
        {
            return View(new ShipperVM());
        }
        [HttpPost]
        public IActionResult NewShipper(ShipperVM ShipperVM)
        {
            if (_shiDal.AddShipper(ShipperVM))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewShipper");
            }
        }
    }
}
