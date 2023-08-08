using Microsoft.AspNetCore.Mvc.Rendering;
using NorthWind.COMMON.ViewModels.EntityVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.COMMON.ViewModels.AddVM
{
    public class AddOrderVM
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> RequiredDate { get; set; }
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public Nullable<int> ShipVia { get; set; }
        public Nullable<decimal> Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public List<SelectListItem> DropDownCustomers { get; set; }
        public List<SelectListItem> DropDownEmployees { get; set; }
        public List<SelectListItem> DropDownShippers { get; set; }
        public IEnumerable<CustomerVM> customerVMs { get; set; }
        public IEnumerable<EmployeeVM> employeeVMs { get; set; }
        public IEnumerable<ShipperVM> shipperVMs { get; set; }
    }
}
