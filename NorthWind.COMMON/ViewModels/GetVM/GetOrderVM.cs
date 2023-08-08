using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.COMMON.ViewModels.GetVM
{
    public class GetOrderVM
    {
        public int OrderID { get; set; }
        public string Customer { get; set; }
        public string Employee { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public string Shipper { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
    }
}
