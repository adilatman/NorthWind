using Microsoft.AspNetCore.Mvc;
using NorthWind.COMMON.ViewModels.EntityVM;
using NorthWind.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryDAL _catDal;
        public CategoryController(ICategoryDAL catDal)
        {
            _catDal = catDal;
        }
        public IActionResult Index()
        {
            var categories = _catDal.GetCategories();
            return View(categories);
        }
        public IActionResult NewCategory()
        {
            return View(new CategoryVM());
        }
        [HttpPost]
        public IActionResult NewCategory(CategoryVM categoryVM)
        {
            TempData["SuccessMessageCategoryAdd"] = null;
            TempData["ErrorMessageCategoryAdd"] = null;
            if (_catDal.AddCategory(categoryVM))
            {
                TempData["SuccessMessageCategoryAdd"] = "Category added successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessageCategoryAdd"] = "Error adding category.";
                return View("NewCategory");
            }
        }
    }
}
