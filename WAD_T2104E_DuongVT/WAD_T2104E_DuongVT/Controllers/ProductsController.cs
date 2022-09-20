using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WAD_T2104E_DuongVT.Models;

namespace WAD_T2104E_DuongVT.Controllers
{
    public class ProductsController : Controller
    {
        private Data db = new Data();

        // GET: Products
        public ActionResult Index()
        {
            ViewBag.SelectedCategory = new SelectList(db.Categories, "CategoryId", "CategoryName");
            var products = db.Products
                .Include(p => p.Category)
                .OrderBy(p=>p.Name);            
            return View(products.ToList());
        }

        //POST SEARCH
        [HttpPost]
        public ActionResult Search(int? SelectedCategory, string txtName, DateTime? txtDate)
        {
            ViewBag.SelectedCategory = new SelectList(db.Categories, "CategoryId", "CategoryName", SelectedCategory);
            int Id = SelectedCategory.GetValueOrDefault();
            //var products = (from p in db.Products
            //                          where p.CategoryID == Id || !SelectedCategory.HasValue
            //                          where p.Name.Contains(txtName)
            //                          where p.ReleaseDate == txtDate || !txtDate.HasValue
            //                          orderby p.Name
            //                          select p).ToList();
            var products = db.Products
                .Include(p => p.Category)
                .Where(p=>p.Name.Contains(txtName))
                .Where(p=>p.CategoryID==Id|| !SelectedCategory.HasValue)
                .Where(p=>p.ReleaseDate==txtDate || !txtDate.HasValue)
                .OrderBy(p => p.Name);
            return View("_ProductPartialView", products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Name,Price,Quantity,ReleaseDate,CategoryID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Name,Price,Quantity,ReleaseDate,CategoryID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
