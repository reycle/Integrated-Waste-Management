using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Integrated_Waste_Management.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Profile()
        {
            // Retrieve user profile data and pass it to the view
            return View();
        }

        public ActionResult NotificationSettings()
        {
            // Retrieve notification settings data and pass it to the view
            return View();
        }
       
    }
}