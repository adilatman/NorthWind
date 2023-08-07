using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.CORE.Entity
{
    public class Shipper
    {
        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public bool AktifMi { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
