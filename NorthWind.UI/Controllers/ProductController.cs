using Microsoft.AspNetCore.Mvc;
using NorthWind.COMMON.ViewModels;
using NorthWind.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductDAL _proDal;
        private readonly ICategoryDAL _catDal;
        private readonly ISupplierDAL _supDal;
        public ProductController(IProductDAL proDal, ICategoryDAL catDal, ISupplierDAL supDal)
        {
            _proDal = proDal;
            _catDal = catDal;
            _supDal = supDal;
        }
        public IActionResult Index()
        {
            var products = _proDal.ProductTable();
            return View(products);
        }
        public IActionResult NewProduct()
        {
            return View(new AddProductVM()
            {
                DropDownCategories = _catDal.DropDownCagetories(),
                DropDownSuppliers = _supDal.DropDownSuppliers(),
                categoryVMs = _catDal.GetCategories(),
                supplierVMs = _supDal.GetSuppliers()
            });
        }
        [HttpPost]
        public IActionResult NewProduct(AddProductVM addProductVM)
        {
            if (_proDal.AddProduct(addProductVM))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewProduct");
            }
        }
    }
}
