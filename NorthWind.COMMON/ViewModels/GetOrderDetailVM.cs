using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.COMMON.ViewModels
{
    public class GetOrderDetailVM
    {
        public int OrderID { get; set; }
        public string Product { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
    }
}
