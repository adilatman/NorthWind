using Microsoft.AspNetCore.Mvc.Rendering;
using NorthWind.COMMON.ViewModels;
using NorthWind.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind.COMMON.ViewModels.AddVM;
using NorthWind.COMMON.ViewModels.EntityVM;
using NorthWind.COMMON.ViewModels.GetVM;

namespace NorthWind.DAL.Interfaces
{
    public interface IOrderDAL
    {
        IEnumerable<OrderVM> GetOrders();
        List<SelectListItem> DropDownOrders();
        List<GetOrderVM> OrderTable();
        bool AddOrder(AddOrderVM orderVM);
    }
}
