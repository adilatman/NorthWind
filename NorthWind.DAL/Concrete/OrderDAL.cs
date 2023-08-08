using Microsoft.AspNetCore.Mvc.Rendering;
using NorthWind.COMMON.ViewModels;
using NorthWind.COMMON.ViewModels.AddVM;
using NorthWind.COMMON.ViewModels.EntityVM;
using NorthWind.COMMON.ViewModels.GetVM;
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
    public class OrderDAL : IOrderDAL
    {
        private readonly MyDbContext _db;
        public OrderDAL(MyDbContext db)
        {
            _db = db;
        }

        public bool AddOrder(AddOrderVM orderVM)
        {
            bool added = false;
            Order order = new Order()
            {
                OrderID = orderVM.OrderID,
                CustomerID = orderVM.CustomerID,
                EmployeeID = orderVM.EmployeeID,
                OrderDate = orderVM.OrderDate,
                RequiredDate = orderVM.RequiredDate,
                ShippedDate = orderVM.ShippedDate,
                ShipVia = orderVM.ShipVia,
                Freight = orderVM.Freight,
                ShipName = orderVM.ShipName,
                ShipAddress = orderVM.ShipAddress,
                ShipCity = orderVM.ShipCity,
                ShipRegion = orderVM.ShipRegion,
                ShipPostalCode = orderVM.ShipPostalCode,
                ShipCountry = orderVM.ShipCountry
            };
            try
            {
                _db.Orders.Add(order);
                _db.SaveChanges();
                added = true;
            }
            catch (Exception)
            {
                added = false;
            }
            return added;
        }

        public List<SelectListItem> DropDownOrders()
        {
            return _db.Orders.Select(a => new SelectListItem()
            {
                Value = a.OrderID.ToString(),
                Text = a.OrderID.ToString()
            }).ToList();
        }

        public IEnumerable<OrderVM> GetOrders()
        {
            return (from o in _db.Orders
                    select new OrderVM
                    {
                        OrderID = o.OrderID,
                        CustomerID = o.CustomerID,
                        EmployeeID = o.EmployeeID,
                        OrderDate = o.OrderDate,
                        RequiredDate = o.RequiredDate,
                        ShipVia = o.ShipVia,
                        Freight = o.Freight,
                        ShipAddress = o.ShipAddress,
                        ShipCity = o.ShipCity,
                        ShipCountry = o.ShipCountry,
                        ShipName = o.ShipName,
                        ShippedDate = o.ShippedDate,
                        ShipPostalCode = o.ShipPostalCode,
                        ShipRegion = o.ShipRegion
                    }).ToList();
        }

        public List<GetOrderVM> OrderTable()
        {
            var orders = (from o in _db.Orders
                          join c in _db.Customers on o.CustomerID equals c.CustomerID
                          join e in _db.Employees on o.EmployeeID equals e.EmployeeID
                          join s in _db.Shippers on o.ShipVia equals s.ShipperID
                          select new GetOrderVM
                          {
                              OrderID = o.OrderID,
                              Customer = c.CompanyName,
                              Employee = e.FirstName + " " + e.LastName,
                              OrderDate = o.OrderDate,
                              Shipper = s.CompanyName,
                              ShipName = o.ShipName,
                              ShipAddress = o.ShipAddress + " " + o.ShipPostalCode + " " + o.ShipCity + " " + o.ShipRegion + " " + o.ShipCountry
                          }).ToList();
            return orders;
        }
    }
}
