using Microsoft.AspNetCore.Mvc.Rendering;
using NorthWind.COMMON.ViewModels.EntityVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.COMMON.ViewModels.AddVM
{
    public class AddOrderDetailVM
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public List<SelectListItem> DropDownOrders { get; set; }
        public List<SelectListItem> DropDownProducts { get; set; }
        public IEnumerable<OrderVM> orderVMs { get; set; }
        public IEnumerable<ProductVM> productVMs { get; set; }
    }
}
