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
    public class EmployeeDAL : IEmployeeDAL
    {
        private readonly MyDbContext _db;
        public EmployeeDAL(MyDbContext db)
        {
            _db = db;
        }

        public List<SelectListItem> DropDownEmployees()
        {
            return _db.Employees.Select(a => new SelectListItem()
            {
                Value = a.EmployeeID.ToString(),
                Text = a.LastName
            }).ToList();
        }

        public IEnumerable<EmployeeVM> GetEmployees()
        {
            return (from e in _db.Employees
                    where e.AktifMi == true
                    select new EmployeeVM {
                        EmployeeID = e.EmployeeID,
                        FirstName=e.FirstName,
                        LastName=e.LastName,
                        TitleOfCourtesy = e.TitleOfCourtesy,
                        Title = e.Title,
                        BirthDate = e.BirthDate,
                        HireDate = e.HireDate,
                        Address = e.Address,
                        PostalCode=e.PostalCode,
                        City=e.City,
                        Region=e.Region,
                        Country=e.Country,
                        HomePhone = e.HomePhone,
                        Extension=e.Extension,
                        ReportsTo = e.ReportsTo,
                        Notes = e.Notes                        
                    }).ToList();

        }
        public List<GetEmployeeVM> EmployeeTable()
        {
            return (from e in _db.Employees
                    where e.AktifMi == true
                    join emp in _db.Employees on e.ReportsTo equals emp.EmployeeID
                    select new GetEmployeeVM
                    {
                        EmployeeID = e.EmployeeID,
                        TitleOfCourtesy = e.TitleOfCourtesy,
                        Name = e.FirstName + " " + e.LastName,
                        Title = e.Title,
                        BirthDate = e.BirthDate,
                        HireDate = e.HireDate,
                        Address = e.Address + ", " + e.PostalCode + ", " + e.City + ", " + e.Region + ", " + e.Country,
                        Phone = e.HomePhone + "-" + e.Extension,
                        ReportsTo = emp.FirstName + " " + emp.LastName,
                        Notes = e.Notes
                    }).ToList();
        }

        public bool AddEmployee(AddEmployeeVM employeeVM)
        {
            bool added = false;
            Employee employee = new Employee()
            {
                EmployeeID = employeeVM.EmployeeID,
                FirstName= employeeVM.FirstName,
                LastName= employeeVM.LastName,
                Title = employeeVM.Title,
                TitleOfCourtesy = employeeVM.TitleOfCourtesy,
                ReportsTo = employeeVM.ReportsTo,
                BirthDate = employeeVM.BirthDate,
                HireDate = employeeVM.HireDate,
                Address = employeeVM.Address,
                City = employeeVM.City,
                Region = employeeVM.Region,
                PostalCode = employeeVM.PostalCode,
                Country = employeeVM.Country,
                HomePhone = employeeVM.HomePhone,
                Extension = employeeVM.Extension,
                Notes = employeeVM.Notes,
                AktifMi = true
            };
            try
            {
                _db.Employees.Add(employee);
                _db.SaveChanges();
                added = true;
            }
            catch (Exception)
            {
                added = false;
            }
            return added;
        }
    }
}
