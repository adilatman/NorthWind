using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.COMMON.ViewModels.GetVM
{
    public class GetProductVM
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Supplier { get; set; }
        public string Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsInOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
