using Integrated_Waste_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integrated_Waste_Management.Controllers
{
    public class DashboardController : Controller
    {
        private LandfillWaste db = new LandfillWaste();
        private compostEntities compostDb = new compostEntities();
        private SlodEntities soldDb = new SlodEntities();

        // GET: Dashboard
        public ActionResult Index()
        {
            var landfillTotal = db.LandfillWasteEntries.Sum(l => l.WeightInLbs);
            var compostTotal = compostDb.CompostEntries.Sum(c => c.WeightInLbs);
            var soldRevenueTotal = soldDb.Solds.Sum(s => s.RevenueGenerated);

            ViewBag.TotalWeight = landfillTotal;
            ViewBag.CompostTotal = compostTotal;
            ViewBag.RecyclingRevenueTotal = soldRevenueTotal;

            return View();
        }
    }
}