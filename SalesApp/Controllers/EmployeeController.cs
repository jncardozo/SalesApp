using Application.Services.Employee.Interfaces;
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
    public class EmployeeController : Controller
    {
        private IEmployeeAppServices _employeeAppServices;

        public EmployeeController(
            IEmployeeAppServices employeeAppServices)
        {
            _employeeAppServices = employeeAppServices;
        }

        //[Authorize]
        public ActionResult Index(string custName, string searchString)
        {
            var customers = from m in _employeeAppServices.GetAll()
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
            var movie = _employeeAppServices.GetById(id);
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
        public ActionResult Create([Bind(Include = "Id,Name,Surname,DocNum,BirthDate,Age,FileNumber")] Employees employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeAppServices.Insert(employee);
                    _employeeAppServices.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError("Unable to save changes. Try again, and if the problem persists contact your system administrator.", dex);
            }
            return View(employee);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = _employeeAppServices.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Movies/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,DocNum,BirthDate,Age,FileNumber")] Employees employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeAppServices.Update(employee);
                    _employeeAppServices.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError("Unable to save changes. Try again, and if the problem persists contact your system administrator.", dex);
            }
            return View(employee);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(bool? saveChangesError = false, int id = 0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            var employee = _employeeAppServices.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var employee = _employeeAppServices.GetById(id);
            _employeeAppServices.Delete(id);
            _employeeAppServices.Save();
            return RedirectToAction("Index");
        }
    }
}