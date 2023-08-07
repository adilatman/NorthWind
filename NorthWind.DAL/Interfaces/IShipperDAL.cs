using Microsoft.AspNetCore.Mvc.Rendering;
using NorthWind.COMMON.ViewModels;
using NorthWind.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.DAL.Interfaces
{
    public interface IShipperDAL
    {
        IEnumerable<ShipperVM> GetShippers();
        List<SelectListItem> DropDownShippers();
        bool AddShipper(ShipperVM shipperVM);
    }
}
