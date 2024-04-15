using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Integrated_Waste_Management.Models;

namespace Integrated_Waste_Management.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (user.Username == "admin" && user.Password == "admin")
            {
                user.Role = "admin";
                return RedirectToAction("AdminDashboard");
            }
            else if (user.Username == "user" && user.Password == "user")
            {
                user.Role = "user";
                return RedirectToAction("UserDashboard");
            }
            else
            {
                ViewBag.Error = "Invalid username or password";
                return View();
            }
        }

        public ActionResult AdminDashboard()
        {
            return View();
        }

        public ActionResult UserDashboard()
        {
            return View();
        }
         public ActionResult Logout()
        {
            // Perform logout actions (e.g., clear session) and redirect to login page
            return RedirectToAction("Login", "Account");
        }
    }
}