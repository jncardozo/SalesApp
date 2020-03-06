using Application.Services.Customer.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SalesApp.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerAppServices _customerAppServices;

        public CustomerController(
            ICustomerAppServices customerAppServices)
        {
            _customerAppServices = customerAppServices;
        }
        
        
        //[Authorize]
        public ActionResult Index(string custName, string searchString)
        {
            var customers = from m in _customerAppServices.GetAll()
                         select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(s => s.Name.Contains(searchString));
            }
            return View(customers);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            var movie = _customerAppServices.GetById(id);
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Surname,DocNum,BirthDate,Age,CreditCard")] Customers customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _customerAppServices.Insert(customer);
                    _customerAppServices.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex )
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError("Unable to save changes. Try again, and if the problem persists contact your system administrator.", dex);
            }
            return View(customer);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customer = _customerAppServices.GetById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Movies/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,DocNum,BirthDate,Age,CreditCard")] Customers customers)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _customerAppServices.Update(customers);
                    _customerAppServices.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError("Unable to save changes. Try again, and if the problem persists contact your system administrator.", dex);
            }
            return View(customers);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(bool? saveChangesError = false, int id = 0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            var customer = _customerAppServices.GetById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var customer = _customerAppServices.GetById(id);
            _customerAppServices.Delete(id);
            _customerAppServices.Save();
            return RedirectToAction("Index");
        }
    }
}