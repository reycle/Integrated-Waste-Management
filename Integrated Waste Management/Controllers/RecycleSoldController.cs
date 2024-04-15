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
    public class RecycleSoldController : Controller
    {
        private SlodEntities db = new SlodEntities();

        // GET: RecycleSold
        public ActionResult Index()
        {
            // Retrieve sold items from the database
            var soldItems = db.Solds.ToList();

            // Calculate total weight pounds
            decimal totalWeightPounds = (decimal)soldItems.Sum(s => s.WeightPounds);

            // Calculate total revenue generated
            decimal totalRevenueGenerated = (decimal)soldItems.Sum(s => s.RevenueGenerated);

            // Pass sold items, total weight pounds, and total revenue generated to the view
            ViewBag.TotalWeightPounds = totalWeightPounds;
            ViewBag.TotalRevenueGenerated = totalRevenueGenerated;

            return View(soldItems);

        }

        // GET: RecycleSold/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sold sold = db.Solds.Find(id);
            if (sold == null)
            {
                return HttpNotFound();
            }
            return View(sold);
        }

        // GET: RecycleSold/Create
        public ActionResult Create()
        {
            // Define the list of waste types
            var RecyclesTypes = new List<string> { "Plastic", "Glass", "Paper", "Metal", "Cardboard" };

            // Create a new Sold object
            var sold = new Sold
            {
                RecyclableTypes = RecyclesTypes
            };

            return View(sold);
        }

        // POST: RecycleSold/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaleID,RecyclableType,categories,SaleDate,WeightPounds,BuyerName,RevenueGenerated")] Sold sold)
        {
            if (ModelState.IsValid)
            {
                db.Solds.Add(sold);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // If the model state is not valid, return the view with the model
            // Here you need to repopulate the recyclable types and categories dropdowns
            var RecyclesTypes = new List<string> { "Plastic", "Glass", "Paper", "Metal", "Cardboard" };
            sold.RecyclableTypes = RecyclesTypes;

            // Filter categories based on the selected recyclable type
            sold.CategorysL = GetFilteredCategories(sold.RecyclableType);

            return View(sold);
        }

        private List<string> GetFilteredCategories(string recyclableType)
        {
            // Define categories based on the selected recyclable type
            switch (recyclableType)
            {
                case "Plastic":
                    return new List<string> { "PET", "HDPE Colored", "HDPE Natural" };
                case "Glass":
                    return new List<string> { "Glass" };
                case "Paper":
                    return new List<string> { "Mixed Paper", "Newspaper", "White Office" };
                case "Metal":
                    return new List<string> { "Aluminum", "Food cans", "Scrap metal" };
                case "Cardboard":
                    return new List<string> { "Cardboard" };

                // Add other recyclable types and their corresponding categories here
                default:
                    return new List<string>();
            }
        }

        // GET: RecycleSold/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sold sold = db.Solds.Find(id);
            if (sold == null)
            {
                return HttpNotFound();
            }
            return View(sold);
        }

        // POST: RecycleSold/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaleID,RecyclableType,categories,SaleDate,WeightPounds,BuyerName,RevenueGenerated")] Sold sold)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sold).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sold);
        }

        // GET: RecycleSold/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sold sold = db.Solds.Find(id);
            if (sold == null)
            {
                return HttpNotFound();
            }
            return View(sold);
        }

        // POST: RecycleSold/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sold sold = db.Solds.Find(id);
            db.Solds.Remove(sold);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Action to fetch categories based on the selected recyclable type
        public ActionResult GetCategories(string recyclableType)
        {
            // Call the GetFilteredCategories method
            var categories = GetFilteredCategories(recyclableType);

            // Return the categories as JSON
            return Json(categories, JsonRequestBehavior.AllowGet);
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
