using Microsoft.AspNetCore.Mvc;
using System.IO;
using NorthWind.COMMON.ViewModels.EntityVM;
using NorthWind.DAL.Interfaces;
using System.Collections.Generic;
using System.Text;
using iText.Html2pdf;
using iText.IO.Source;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using System.Data;
using ClosedXML.Excel;

namespace NorthWind.UI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerDAL _cusDal;
        public CustomerController(ICustomerDAL cusDal)
        {
            _cusDal = cusDal;
        }
        public IActionResult Index()
        {
            var customers = _cusDal.CustomerList();
            return View(customers);
        }
        public IActionResult NewCustomer()
        {
            return View(new CustomerVM());
        }
        [HttpPost]
        public IActionResult NewCustomer(CustomerVM customerVM)
        {
            TempData["SuccessMessageCustomerAdd"] = null;
            TempData["ErrorMessageCustomerAdd"] = null;
            if (_cusDal.AddCustomer(customerVM))
            {
                TempData["SuccessMessageCustomerAdd"] = "Customer added successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessageCustomerAdd"] = "Error adding customer.";
                return View("NewCustomer");
            }
        }
        public FileResult ExportPDF()
        {
            List<object> customers = _cusDal.GetForExport();
            StringBuilder sb = new StringBuilder();
            sb.Append("<table border='1' cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-family: Arial; font-size: 10pt;'>");
            sb.Append("<tr>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>CustomerID</th>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>ContactName</th>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>City</th>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>Country</th>");
            sb.Append("</tr>");
            for (int i = 0; i < customers.Count; i++)
            {
                string[] customer = (string[])customers[i];
                sb.Append("<tr>");
                for (int j = 0; j < customer.Length; j++)
                {
                    //Append data.
                    sb.Append("<td style='border: 1px solid #ccc'>");
                    sb.Append(customer[j]);
                    sb.Append("</td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            using (MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(sb.ToString())))
            {
                ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
                PdfWriter writer = new PdfWriter(byteArrayOutputStream);
                PdfDocument pdfDocument = new PdfDocument(writer);
                pdfDocument.SetDefaultPageSize(PageSize.A4);
                HtmlConverter.ConvertToPdf(stream, pdfDocument);
                pdfDocument.Close();
                return File(byteArrayOutputStream.ToArray(), "application/pdf", "Grid.pdf");
            }
        }
        public FileResult ExportWord()
        {
            List<object> customers = _cusDal.GetForExport();
            StringBuilder sb = new StringBuilder();
            sb.Append("<table border='1' cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-family: Arial; font-size: 10pt;'>");
            sb.Append("<tr>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>CustomerID</th>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>ContactName</th>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>City</th>");
            sb.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>Country</th>");
            sb.Append("</tr>");
            for (int i = 0; i < customers.Count; i++)
            {
                string[] customer = (string[])customers[i];
                sb.Append("<tr>");
                for (int j = 0; j < customer.Length; j++)
                {
                    //Append data.
                    sb.Append("<td style='border: 1px solid #ccc'>");
                    sb.Append(customer[j]);
                    sb.Append("</td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            return File(Encoding.UTF8.GetBytes(sb.ToString()), "application/vnd.ms-word", "Grid.doc");
        }
        public FileResult ExportExcel()
        {
            var customers = _cusDal.GetCustomers();
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4]
            {
                new DataColumn("CustomerID"),
                new DataColumn("ContactName"),
                new DataColumn("City"),
                new DataColumn("Country"),
            });
            foreach (var customer in customers)
            {
                dt.Rows.Add(customer.CustomerID, customer.ContactName, customer.City, customer.Country);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt,"Sheet1");
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                }
            }
        }
    }
}
