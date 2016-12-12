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

                addActivity.Venue = collection["Venue"];
                db2.Activities.Add(addActivity);
                db2.SaveChanges();

                return RedirectToAction("Index","Home");
            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.InnerException;
                return View();
            }
        }
    }
}
