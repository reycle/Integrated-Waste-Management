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
    public class RecyclablesController : Controller
    {
        private RecyclablesEntities db = new RecyclablesEntities();

        // GET: Recyclables
        public ActionResult Index()
        {
            // Retrieve recyclables from the database
            var recyclables = db.Recyclables.ToList();

            // Calculate total weight of recyclables
            decimal totalWeight = recyclables.Sum(r => r.WeightInLbs);

            // Pass recyclables and total weight to the view
            ViewBag.TotalWeight = totalWeight;
            return View(recyclables);
        }

        // GET: Recyclables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recyclable recyclable = db.Recyclables.Find(id);
            if (recyclable == null)
            {
                return HttpNotFound();
            }
            return View(recyclable);
        }

        // GET: Recyclables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recyclables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,WeightInLbs")] Recyclable recyclable)
        {
            if (ModelState.IsValid)
            {
                db.Recyclables.Add(recyclable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recyclable);
        }

        // GET: Recyclables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recyclable recyclable = db.Recyclables.Find(id);
            if (recyclable == null)
            {
                return HttpNotFound();
            }
            return View(recyclable);
        }

        // POST: Recyclables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,WeightInLbs")] Recyclable recyclable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recyclable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recyclable);
        }

        // GET: Recyclables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recyclable recyclable = db.Recyclables.Find(id);
            if (recyclable == null)
            {
                return HttpNotFound();
            }
            return View(recyclable);
        }

        // POST: Recyclables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recyclable recyclable = db.Recyclables.Find(id);
            db.Recyclables.Remove(recyclable);
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
