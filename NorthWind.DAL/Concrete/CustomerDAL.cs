using Microsoft.AspNetCore.Mvc.Rendering;
using NorthWind.COMMON.ViewModels;
using NorthWind.COMMON.ViewModels.EntityVM;
using NorthWind.COMMON.ViewModels.GetVM;
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
    public class CustomerDAL:ICustomerDAL
    {
        private readonly MyDbContext _db;
        public CustomerDAL(MyDbContext db)
        {
            _db = db;
        }
                
        public List<SelectListItem> DropDownCustomers()
        {
            return _db.Customers.Select(a => new SelectListItem()
            {
                Value = a.CustomerID,
                Text = a.CompanyName
            }).ToList();
        }

        public IEnumerable<CustomerVM> GetCustomers()
        {
            return (from s in _db.Customers
                    select new CustomerVM
                    {
                        CustomerID = s.CustomerID,
                        CompanyName = s.CompanyName,
                        ContactName = s.ContactName,
                        ContactTitle = s.ContactTitle,
                        Address = s.Address,
                        PostalCode = s.PostalCode,
                        City = s.City,
                        Region = s.Region,
                        Country = s.Country,
                        Phone = s.Phone,
                        Fax = s.Fax
                    }).ToList();
        }
        public List<object> GetForExport()
        {
            return (from s in _db.Customers
                    select new []
                    {
                        s.CustomerID,
                        s.ContactName,
                        s.City,
                        s.Country
                    }).ToList<object>();
        }
        public List<GetCustomerVM> CustomerList()
        {
            var customers = (from c in _db.Customers
                             select new GetCustomerVM
                             {
                                 CustomerID = c.CustomerID,
                                 CompanyName = c.CompanyName,
                                 ContactName = c.ContactName,
                                 ContactTitle = c.ContactTitle,
                                 Address = c.Address + " " + c.PostalCode + " " + c.City + " " + c.Region + " " + c.Country,
                                 Phone = c.Phone,
                                 Fax = c.Fax
                             }).ToList();
            return customers;
        }

        public bool AddCustomer(CustomerVM customerVM)
        {
            bool added = false;
            Customer customer = new Customer()
            {
                CustomerID = customerVM.CustomerID,
                CompanyName = customerVM.CompanyName,
                ContactName = customerVM.ContactName,
                ContactTitle = customerVM.ContactTitle,
                Address = customerVM.Address,
                City = customerVM.City,
                Region = customerVM.Region,
                PostalCode = customerVM.PostalCode,
                Country = customerVM.Country,
                Phone = customerVM.Phone,
                Fax = customerVM.Fax
            };
            try
            {
                _db.Customers.Add(customer);
                added = _db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                added = false;
            }
            return added;
        }
    }
}
