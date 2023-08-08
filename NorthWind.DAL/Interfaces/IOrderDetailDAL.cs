using Microsoft.AspNetCore.Mvc.Rendering;
using NorthWind.COMMON.ViewModels;
using NorthWind.COMMON.ViewModels.AddVM;
using NorthWind.COMMON.ViewModels.EntityVM;
using NorthWind.COMMON.ViewModels.GetVM;
using NorthWind.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.DAL.Interfaces
{
    public interface IOrderDetailDAL
    {
        IEnumerable<OrderDetailVM> GetOrderDetails();
        List<SelectListItem> DropDownOrderDetails();
        List<GetOrderDetailVM> OrderDetailTable();
        bool AddOrderDetail(AddOrderDetailVM orderDetailVM);
    }
}
