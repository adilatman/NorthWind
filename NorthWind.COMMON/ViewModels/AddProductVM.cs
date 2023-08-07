using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.COMMON.ViewModels
{
    public class AddProductVM
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<short> UnitsInStock { get; set; }
        public Nullable<short> UnitsOnOrder { get; set; }
        public Nullable<short> ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public bool AktifMi { get; set; }
        public List<SelectListItem> DropDownCategories { get; set; }
        public List<SelectListItem> DropDownSuppliers { get; set; }
        public IEnumerable<CategoryVM> categoryVMs { get; set; }
        public IEnumerable<SupplierVM> supplierVMs { get; set; }
    }
}
