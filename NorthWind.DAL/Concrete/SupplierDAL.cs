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
    public class SupplierDAL:ISupplierDAL
    {
        private readonly MyDbContext _db;
        public SupplierDAL(MyDbContext db)
        {
            _db = db;
        }

        public bool AddSupplier(SupplierVM supplierVM)
        {
            bool added = false;
            Supplier supplier = new Supplier()
            {
                SupplierID = supplierVM.SupplierID,
                CompanyName = supplierVM.CompanyName,
                ContactName = supplierVM.ContactName,
                ContactTitle = supplierVM.ContactTitle,
                Address = supplierVM.Address,
                City = supplierVM.City,
                Region = supplierVM.Region,
                PostalCode = supplierVM.PostalCode,
                Country = supplierVM.Country,
                Phone = supplierVM.Phone,
                Fax = supplierVM.Fax,
                HomePage=supplierVM.HomePage,
                AktifMi = true
            };
            try
            {
                _db.Suppliers.Add(supplier);
                added = _db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                added = false;
            }
            return added;
        }

        public List<SelectListItem> DropDownSuppliers()
        {
            return _db.Suppliers.Select(a => new SelectListItem()
            {
                Value = a.SupplierID.ToString(),
                Text = a.CompanyName
            }).ToList();
        }
        public IEnumerable<SupplierVM> GetSuppliers()
        {
            return (from s in _db.Suppliers
                where s.AktifMi==true
                select new SupplierVM { 
                SupplierID=s.SupplierID,
                CompanyName=s.CompanyName,
                ContactName=s.ContactName,
                ContactTitle=s.ContactTitle,
                Address=s.Address,
                PostalCode=s.PostalCode,
                City=s.City,
                Region=s.Region,
                Country=s.Country,
                Phone=s.Phone,
                Fax=s.Fax,
                HomePage=s.HomePage
                }).ToList();

        }

        public List<GetSupplierVM> SupplierList()
        {
            var suppliers = (from s in _db.Suppliers
                             where s.AktifMi == true
                             select new GetSupplierVM
                             {
                                 SupplierID = s.SupplierID,
                                 CompanyName = s.CompanyName,
                                 ContactName = s.ContactName,
                                 ContactTitle = s.ContactTitle,
                                 Address = s.Address + " " + s.PostalCode + " " + s.City + " " + s.Region + " " + s.Country,
                                 Phone = s.Phone,
                                 Fax = s.Fax,
                                 HomePage=s.HomePage
                             }).ToList();
            return suppliers;
        }
    }
}
