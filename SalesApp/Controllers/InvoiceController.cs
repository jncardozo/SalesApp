using Application.Services.Invoice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesApp.Models;
using Application.Services.Customer.Interfaces;

namespace SalesApp.Controllers
{
    public class InvoiceController : Controller
    {
        private IInvoiceHeaderAppServices _invoiceHeaderAppServices;
        private IInvoiceItemAppServices   _invoiceItemAppServices;
        private ICustomerAppServices _customerAppServices;

        public InvoiceController(
            IInvoiceHeaderAppServices invoiceHeaderAppServices,
            IInvoiceItemAppServices   invoiceItemAppServices,
            ICustomerAppServices      customerAppServices
            )
        {
            _invoiceHeaderAppServices = invoiceHeaderAppServices;
            _invoiceItemAppServices   = invoiceItemAppServices;
            _customerAppServices = customerAppServices;
        }


        //[Authorize]
        public ActionResult Index(string custName, string searchString)
        {
            var invoiceHeaders = _invoiceHeaderAppServices.GetAll().ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                invoiceHeaders = invoiceHeaders.Where(s => s.Customers.Surname.Contains(searchString)).ToList();
            }
            return View(invoiceHeaders);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            var invoice = _invoiceHeaderAppServices.GetById(id);
            return View(invoice);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Customer(string q)
        {
            var items = _customerAppServices.GetAll()
                .Where(c => c.Name.ToLower().Contains(q.ToLower()) || c.Surname.ToLower().Contains(q.ToLower()))
                .Select(u => new { id = u.Id, name = u.Name, surname = u.Surname});

            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SalesInvoice(int id)
        {
            var invoice = _invoiceHeaderAppServices.GetById(id);
            return View(invoice);
        }

    }
}