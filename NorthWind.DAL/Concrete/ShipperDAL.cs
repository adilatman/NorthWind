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
    public class ShipperDAL:IShipperDAL
    {
        private readonly MyDbContext _db;
        public ShipperDAL(MyDbContext db)
        {
            _db = db;
        }

        public bool AddShipper(ShipperVM shipperVM)
        {
            bool added = false;
            Shipper shipper = new Shipper()
            {
                ShipperID = shipperVM.ShipperID,
                CompanyName = shipperVM.CompanyName,
                Phone = shipperVM.Phone,
                AktifMi = true
            };
            try
            {
                _db.Shippers.Add(shipper);
                added = _db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                added = false;
            }
            return added;
        }

        public List<SelectListItem> DropDownShippers()
        {
            return _db.Shippers.Select(a => new SelectListItem()
            {
                Value = a.ShipperID.ToString(),
                Text = a.CompanyName
            }).ToList();
        }

        public IEnumerable<ShipperVM> GetShippers()
        {
            return (from s in _db.Shippers
                   where s.AktifMi==true
                   select new ShipperVM { 
                   ShipperID=s.ShipperID,
                   CompanyName=s.CompanyName,
                   Phone=s.Phone
                   }).ToList();
        }
    }
}
