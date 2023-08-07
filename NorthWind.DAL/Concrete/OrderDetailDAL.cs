using Microsoft.AspNetCore.Mvc.Rendering;
using NorthWind.COMMON.ViewModels;
using NorthWind.CORE.Context;
using NorthWind.CORE.Entity;
using NorthWind.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.DAL.Concrete
{
    public class OrderDetailDAL : IOrderDetailDAL
    {
        private readonly MyDbContext _db;
        public OrderDetailDAL(MyDbContext db)
        {
            _db = db;
        }

        public bool AddOrderDetail(AddOrderDetailVM orderDetailVM)
        {
            bool added = false;
            OrderDetail orderDetail = new OrderDetail()
            {
                OrderDetailID=orderDetailVM.OrderDetailID,
                OrderID = orderDetailVM.OrderID,
                ProductID = orderDetailVM.ProductID,
                UnitPrice = orderDetailVM.UnitPrice,
                Quantity = orderDetailVM.Quantity,
                Discount = orderDetailVM.Discount
            };
            try
            {
                _db.OrderDetails.Add(orderDetail);
                _db.SaveChanges();
                added = true;
            }
            catch (Exception)
            {
                added = false;
            }
            return added;
        }

        public List<SelectListItem> DropDownOrderDetails()
        {
            return _db.Orders.Select(a => new SelectListItem()
            {
                Value = a.OrderID.ToString(),
                Text = a.OrderID.ToString()
            }).ToList();
        }

        public IEnumerable<OrderDetailVM> GetOrderDetails()
        {
            return (from od in _db.OrderDetails
                    select new OrderDetailVM {
                    OrderID=od.OrderID,
                    ProductID=od.ProductID,
                    UnitPrice=od.UnitPrice,
                    Quantity=od.Quantity,
                    Discount=od.Discount
                    }).ToList();
        }

        public List<GetOrderDetailVM> OrderDetailTable()
        {
            var orderDetails = (from od in _db.OrderDetails
                                join p in _db.Products on od.ProductID equals p.ProductID
                                select new GetOrderDetailVM
                                {
                                    OrderID = od.OrderID,
                                    Product = p.ProductName,
                                    UnitPrice = od.UnitPrice,
                                    Quantity = od.Quantity,
                                    Discount = od.Discount
                                }).ToList();
            return orderDetails;

        }
    }
}
