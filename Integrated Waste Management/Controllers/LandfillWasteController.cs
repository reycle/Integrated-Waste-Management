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
    public class LandfillWasteController : Controller
    {
        private LandfillWaste db = new LandfillWaste();

        // GET: LandfillWaste
        public ActionResult Index()
        {

             // Retrieve landfill waste entries from the database
            var landfillWasteEntries = db.LandfillWasteEntries.ToList();

            // Calculate total weight of landfill waste entries
            decimal totalWeight = landfillWasteEntries.Sum(c => c.WeightInLbs);

            // Pass landfill waste entries and total weight to the view
            ViewBag.TotalWeight = totalWeight;
            return View(landfillWasteEntries);
        }

        // GET: LandfillWaste/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LandfillWasteEntry landfillWasteEntry = db.LandfillWasteEntries.Find(id);
            if (landfillWasteEntry == null)
            {
                return HttpNotFound();
            }
            return View(landfillWasteEntry);
        }

        // GET: LandfillWaste/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LandfillWaste/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,WeightInLbs")] LandfillWasteEntry landfillWasteEntry)
        {
            if (ModelState.IsValid)
            {
                db.LandfillWasteEntries.Add(landfillWasteEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(landfillWasteEntry);
        }

        // GET: LandfillWaste/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LandfillWasteEntry landfillWasteEntry = db.LandfillWasteEntries.Find(id);
            if (landfillWasteEntry == null)
            {
                return HttpNotFound();
            }
            return View(landfillWasteEntry);
        }

        // POST: LandfillWaste/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,WeightInLbs")] LandfillWasteEntry landfillWasteEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(landfillWasteEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(landfillWasteEntry);
        }

        // GET: LandfillWaste/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LandfillWasteEntry landfillWasteEntry = db.LandfillWasteEntries.Find(id);
            if (landfillWasteEntry == null)
            {
                return HttpNotFound();
            }
            return View(landfillWasteEntry);
        }

        // POST: LandfillWaste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LandfillWasteEntry landfillWasteEntry = db.LandfillWasteEntries.Find(id);
            db.LandfillWasteEntries.Remove(landfillWasteEntry);
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
