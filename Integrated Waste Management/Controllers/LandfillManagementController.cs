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
    public class LandfillManagementController : Controller
    {
        private LFWMCS db = new LFWMCS();

        // GET: LandfillManagement
        public ActionResult Index()
        {
            // Retrieve landfill entries from the database
            var landfillEntries = db.LFWMs.ToList();

            // Calculate total weight pounds
            decimal totalWeightPounds = (decimal)landfillEntries.Sum(l => l.WeightPounds);

            // Calculate total landfill fees
            decimal totalLandfillFees = (decimal)landfillEntries.Sum(l => l.LandfillFees);

            // Pass landfill entries, total weight pounds, and total landfill fees to the view
            ViewBag.TotalWeightPounds = totalWeightPounds;
            ViewBag.TotalLandfillFees = totalLandfillFees;

            return View(landfillEntries);
        }

        // GET: LandfillManagement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LFWM lFWM = db.LFWMs.Find(id);
            if (lFWM == null)
            {
                return HttpNotFound();
            }
            return View(lFWM);
        }

        // GET: LandfillManagement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LandfillManagement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LandfillID,WasteDate,WeightPounds,LandfillFees")] LFWM lFWM)
        {
            if (ModelState.IsValid)
            {
                db.LFWMs.Add(lFWM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lFWM);
        }

        // GET: LandfillManagement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LFWM lFWM = db.LFWMs.Find(id);
            if (lFWM == null)
            {
                return HttpNotFound();
            }
            return View(lFWM);
        }

        // POST: LandfillManagement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LandfillID,WasteDate,WeightPounds,LandfillFees")] LFWM lFWM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lFWM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lFWM);
        }

        // GET: LandfillManagement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LFWM lFWM = db.LFWMs.Find(id);
            if (lFWM == null)
            {
                return HttpNotFound();
            }
            return View(lFWM);
        }

        // POST: LandfillManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LFWM lFWM = db.LFWMs.Find(id);
            db.LFWMs.Remove(lFWM);
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
