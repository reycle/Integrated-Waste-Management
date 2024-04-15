using Integrated_Waste_Management.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Integrated_Waste_Management.Controllers
{
    public class NotificationSettingsController : Controller
    {
        private NotificationSettingsEntities db = new NotificationSettingsEntities();

        // GET: NotificationSettings
        public ActionResult Index()
        {
            List<NotificationSetting> notificationSettings = db.NotificationSettings.ToList();
            return View(notificationSettings);
        }

        // GET: NotificationSettings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotificationSetting notificationSetting = db.NotificationSettings.Find(id);
            if (notificationSetting == null)
            {
                return HttpNotFound();
            }
            return View(notificationSetting);
        }

        // POST: NotificationSettings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,NotificationType,Enabled")] NotificationSetting notificationSetting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notificationSetting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notificationSetting);
        }

        // Dispose the DbContext
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