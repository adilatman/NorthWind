﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWind.COMMON.ViewModels
{
    public class AddEmployeeVM
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public string Notes { get; set; }
        public Nullable<int> ReportsTo { get; set; }
        public bool AktifMi { get; set; }
        public List<SelectListItem> DropDownReportsTo { get; set; }
        public IEnumerable<EmployeeVM> employeeVMs { get; set;  }
    }
}
