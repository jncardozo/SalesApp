using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesApp.Models
{
    public class InvoiceModels
    {
        public InvoiceModels(InvoiceHeader invoiceHeader)
        {
            CustName = invoiceHeader.Customers.Name;
            EmpName  = $"{invoiceHeader.Customers.Surname}-{invoiceHeader.Employees.Name}";
            FileNum  = invoiceHeader.Employees.FileNumber;
            Products = invoiceHeader.InvoiceItems.Select(it => it.Products);
        }

        public string CustName { get; set; }
        public string EmpName  { get; set; }
        public string FileNum  { get; set; }
        public IEnumerable<Products> Products { get; set; }
    }

    public class ProductModels
    {

        public ProductModels(Products product)
        {
            Name = product.Name;
            UnitPrice = product.UnitPrice;
        }

        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}