using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Integrated_Waste_Management.Models;

namespace Integrated_Waste_Management.Controllers
{
    public class CategoryManagementController : Controller
    {
        private CategoryEntities db = new CategoryEntities();

        // GET: CategoryManagement
        public ActionResult Index()
        {
            // Retrieve category managements from the database
            var categoryManagements = db.CategoryManagements.ToList();

            // Calculate total weight pounds
            decimal totalWeightPounds = categoryManagements.Sum(c => c.WeightPounds ?? 0);

            // Pass category managements and total weight pounds to the view
            ViewBag.TotalWeightPounds = totalWeightPounds;
            return View(categoryManagements);
        }

        // GET: CategoryManagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryManagement categoryManagement = db.CategoryManagements.Find(id);
            if (categoryManagement == null)
            {
                return HttpNotFound();
            }
            return View(categoryManagement);
        }

        // GET: CategoryManagement/Create
        public ActionResult Create()
        {
            // Define the list of waste types
            var wasteTypes = new List<string> { "Plastic" };

            // Define the list of categories
            var categories = new List<string> {"PET","HDPE Colored", "HDPE Natural" };

            // Create a new CategoryManagement object and assign the dropdown lists
            var categoryManagement = new CategoryManagement
            {
                WasteTypeNames = wasteTypes,
                Categories = categories
            };

            return View(categoryManagement);
        }


           

        // POST: CategoryManagement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WasteTypeID,WasteTypeName,Category,WeightPounds,DateTime")] CategoryManagement categoryManagement)
        {
            if (ModelState.IsValid)
            {
                db.CategoryManagements.Add(categoryManagement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoryManagement);
        }

        // GET: CategoryManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryManagement categoryManagement = db.CategoryManagements.Find(id);
            if (categoryManagement == null)
            {
                return HttpNotFound();
            }
            return View(categoryManagement);
        }

        // POST: CategoryManagement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WasteTypeID,WasteTypeName,Category,WeightPounds,DateTime")] CategoryManagement categoryManagement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryManagement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoryManagement);
        }

        // GET: CategoryManagement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryManagement categoryManagement = db.CategoryManagements.Find(id);
            if (categoryManagement == null)
            {
                return HttpNotFound();
            }
            return View(categoryManagement);
        }

        // POST: CategoryManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoryManagement categoryManagement = db.CategoryManagements.Find(id);
            db.CategoryManagements.Remove(categoryManagement);
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
