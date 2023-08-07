using Microsoft.AspNetCore.Mvc.Rendering;
using NorthWind.COMMON.ViewModels;
using NorthWind.CORE.Context;
using NorthWind.CORE.Entity;
using NorthWind.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.DAL.Concrete
{
    public class CategoryDAL:ICategoryDAL
    {
        private readonly MyDbContext _db;
        public CategoryDAL(MyDbContext db)
        {
            _db = db;
        }

        public bool AddCategory(CategoryVM categoryVM)
        {
            bool added = false;
            Category category = new Category()
            {
                CategoryName=categoryVM.CategoryName,
                Description=categoryVM.Description                
            };
            try
            {
                _db.Categories.Add(category);
                added = _db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                added = false;
            }
            return added;
        }

        public List<SelectListItem> DropDownCagetories()
        {
            return _db.Categories.Select(a => new SelectListItem()
            {
                Value = a.CategoryID.ToString(),
                Text = a.CategoryName
            }).ToList();
        }

        public IEnumerable<CategoryVM> GetCategories()
        {
            return (from c in _db.Categories
                    select new CategoryVM { 
                    CategoryID=c.CategoryID,
                    CategoryName=c.CategoryName,
                    Description=c.Description
                    }).ToList();
        }

    }
}
