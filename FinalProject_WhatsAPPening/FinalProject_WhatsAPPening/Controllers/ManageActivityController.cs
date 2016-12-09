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
            return View();
        }
        // POST:
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            DBActivity db2 = new DBActivity();
            Activity addActivity = new Activity();

            addActivity.Category = collection["Category"];
            addActivity.City = collection["City"];
            addActivity.DaysOpen = collection["DaysOpen"];
            //addActivity.Id = collection["Id"];
            addActivity.Image = collection["Image"];
            addActivity.LengthOfTime = collection["LengthOfTime"];
            addActivity.Link = collection["Link"];
            addActivity.PhoneNumber = collection["PhoneNumber"];
            addActivity.PricePerPerson = collection["PricePerPerson"];
            addActivity.State = collection["State"];
            addActivity.StreetAddress = collection["StreetAddress"];
            addActivity.TimesOpen = collection["TimesOpen"];
            addActivity.Venue = collection["Venue"];
            addActivity.Zip = collection["Zip"];

            db2.Activities.Add(addActivity);
            db2.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
