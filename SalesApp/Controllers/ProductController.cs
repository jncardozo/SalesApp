using Application.Services.Products.Interfaces;
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
    public class ProductController : Controller
    {
        private IProductAppServices _productAppServices;

        public ProductController(
            IProductAppServices productAppServices)
        {
            _productAppServices = productAppServices;
        }

        //[Authorize]
        public ActionResult Index(string prodName, string searchString)
        {
            var products = from m in _productAppServices.GetAll()
                            select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString));
            }
            return View(products);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            var product = _productAppServices.GetById(id);
            return View(product);
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
        public ActionResult Create([Bind(Include = "Id,Name,Brand,ExpirationDate,UnitPrice,Supplier")] Products product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productAppServices.Insert(product);
                    _productAppServices.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError("Unable to save changes. Try again, and if the problem persists contact your system administrator.", dex);
            }
            return View(product);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = _productAppServices.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Movies/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Brand,ExpirationDate,UnitPrice,Supplier")] Products product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productAppServices.Update(product);
                    _productAppServices.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException dex)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError("Unable to save changes. Try again, and if the problem persists contact your system administrator.", dex);
            }
            return View(product);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(bool? saveChangesError = false, int id = 0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            var product = _productAppServices.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = _productAppServices.GetById(id);
            _productAppServices.Delete(id);
            _productAppServices.Save();
            return RedirectToAction("Index");
        }
    }
}