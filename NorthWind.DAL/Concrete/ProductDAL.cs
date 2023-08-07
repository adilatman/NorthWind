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
    public class ProductDAL:IProductDAL
    {
        private readonly MyDbContext _db;
        public ProductDAL(MyDbContext db)
        {
            _db = db;
        }

        public bool AddProduct(AddProductVM productVM)
        {
            bool added = false;
            Product product = new Product()
            {
                ProductID = productVM.ProductID,
                ProductName = productVM.ProductName,
                SupplierID = productVM.SupplierID,
                CategoryID = productVM.CategoryID,
                QuantityPerUnit = productVM.QuantityPerUnit,
                UnitPrice = productVM.UnitPrice,
                UnitsInStock = productVM.UnitsInStock,
                UnitsOnOrder = productVM.UnitsOnOrder,
                ReorderLevel = productVM.ReorderLevel,
                Discontinued = productVM.Discontinued,                
                AktifMi = true
            };
            try
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                added = true;
            }
            catch (Exception)
            {
                added = false;
            }
            return added;
        }

        public List<SelectListItem> DropDownProducts()
        {
            return _db.Products.Select(a => new SelectListItem()
            {
                Value = a.ProductID.ToString(),
                Text = a.ProductName
            }).ToList();
        }

        public IEnumerable<ProductVM> GetProducts()
        {
            return (from p in _db.Products
                   where p.AktifMi==true
                   select new ProductVM {
                   ProductID=p.ProductID,
                   ProductName=p.ProductName,
                   CategoryID=p.CategoryID,
                   SupplierID=p.SupplierID,
                   UnitPrice=p.UnitPrice,
                   QuantityPerUnit=p.QuantityPerUnit,
                   ReorderLevel=p.ReorderLevel,
                   UnitsInStock=p.UnitsInStock,
                   UnitsOnOrder=p.UnitsOnOrder,
                   Discontinued=p.Discontinued
                   }).ToList();
        }

        public List<GetProductVM> ProductTable()
        {
            var productTable = (from p in _db.Products
                                where p.AktifMi == true
                                join c in _db.Categories on p.CategoryID equals c.CategoryID
                                join s in _db.Suppliers on p.SupplierID equals s.SupplierID
                                select new GetProductVM
                                {
                                    ProductID=p.ProductID,
                                    ProductName = p.ProductName,
                                    Category = c.CategoryName,
                                    Supplier = s.CompanyName,
                                    QuantityPerUnit = p.QuantityPerUnit,
                                    UnitPrice = p.UnitPrice,
                                    UnitsInStock = p.UnitsInStock,
                                    UnitsInOrder = p.UnitsOnOrder,
                                    ReorderLevel = p.ReorderLevel,
                                    Discontinued = p.Discontinued
                                }).ToList();
            return productTable;
        }
    }
}
