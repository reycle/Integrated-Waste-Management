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
    public class CompostController : Controller
    {
        private compostEntities db = new compostEntities();

        // GET: Compost
        public ActionResult Index()
        {
            // Retrieve compost entries from the database
            var compostEntries = db.CompostEntries.ToList();

            // Calculate total weight of compost entries
            decimal totalWeight = compostEntries.Sum(c => c.WeightInLbs);

            // Pass compost entries and total weight to the view
            ViewBag.TotalWeight = totalWeight;
            return View(compostEntries);
        }

        // GET: Compost/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompostEntry compostEntry = db.CompostEntries.Find(id);
            if (compostEntry == null)
            {
                return HttpNotFound();
            }
            return View(compostEntry);
        }

        // GET: Compost/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compost/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,WeightInLbs")] CompostEntry compostEntry)
        {
            if (ModelState.IsValid)
            {
                db.CompostEntries.Add(compostEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(compostEntry);
        }

        // GET: Compost/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompostEntry compostEntry = db.CompostEntries.Find(id);
            if (compostEntry == null)
            {
                return HttpNotFound();
            }
            return View(compostEntry);
        }

        // POST: Compost/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,WeightInLbs")] CompostEntry compostEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compostEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compostEntry);
        }

        // GET: Compost/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompostEntry compostEntry = db.CompostEntries.Find(id);
            if (compostEntry == null)
            {
                return HttpNotFound();
            }
            return View(compostEntry);
        }

        // POST: Compost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompostEntry compostEntry = db.CompostEntries.Find(id);
            db.CompostEntries.Remove(compostEntry);
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
