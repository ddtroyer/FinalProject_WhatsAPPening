using FinalProject_WhatsAPPening;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject_WhatsAPPening.Controllers
{
    public class ManageActivityController : Controller
    {
        // GET: ManageActivity
        public ActionResult Create()
        {
            return View("AddActivityView");
        }
        // POST:
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                DBActivity db2 = new DBActivity();
                Activity addActivity = new Activity();

                addActivity.Category = collection["categoryDropdown"];
                addActivity.Venue = collection["Venue"];
                addActivity.Link = collection["Link"];
                addActivity.PricePerPerson = collection["PricePerPerson"];
                addActivity.StreetAddress = collection["StreetAddress"];
                addActivity.City = collection["City"];
                addActivity.State = collection["State"];
                addActivity.Zip = collection["Zip"];
                addActivity.PhoneNumber = collection["PhoneNumber"];
                addActivity.DaysOpen = collection["DaysOpen"];
                addActivity.TimesOpen = collection["TimesOpen"];
                addActivity.Other = collection["Other"];
                db2.Activities.Add(addActivity);
                db2.SaveChanges();

                return RedirectToAction("Index","Home");
            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.InnerException;
                return View("AddActivityView");
            }
        } // GET: ManageActivity
        [Authorize]
        public ActionResult Edit(int id)
        {
                DBActivity db2 = new DBActivity();

                return View(db2.Activities.Find(id));
        }
        // POST:
        [Authorize]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                DBActivity db2 = new DBActivity();
                var foundActivity = db2.Activities.Find(id);

                foundActivity.Venue = collection["Venue"];
                foundActivity.Link = collection["Link"];
                foundActivity.Category = collection["Category"];
                foundActivity.StreetAddress = collection["StreetAddress"];
                foundActivity.City = collection["City"];
                foundActivity.State = collection["State"];
                foundActivity.Zip = collection["Zip"];
                foundActivity.DaysOpen = collection["DaysOpen"];
                foundActivity.TimesOpen = collection["TimesOpen"];
                foundActivity.PricePerPerson = collection["PricePerPerson"];
                foundActivity.PhoneNumber = collection["PhoneNumber"];
                db2.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.InnerException;
                return View();
            }
        }
        [Authorize]
        public ActionResult List()
        {
            DBActivity db2 = new DBActivity();
            return View(db2.Activities.ToList());
        }
        // GET: Activity/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            DBActivity db2 = new DBActivity();
            return View(db2.Activities.Find(id));
        }

        // POST: Activity/Delete/5
        [Authorize]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                DBActivity db2 = new DBActivity();
                var foundActivity = db2.Activities.Find(id);

                db2.Activities.Remove(foundActivity);
                db2.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.InnerException;
                return View();
                
            }
        }
    }
}