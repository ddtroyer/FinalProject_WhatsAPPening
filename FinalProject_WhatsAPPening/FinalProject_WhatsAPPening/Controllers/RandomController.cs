using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using FinalProject_WhatsAPPening.Models;
using FactualDriver;
using Newtonsoft.Json.Linq;
using YelpAPI;
using System.Security.Cryptography.Xml;
using SimpleOAuth;
using System.Web.Mvc;

namespace FinalProject_WhatsAPPening.Controllers
{
    public class RandomController : Controller
    {
        
        public ActionResult RandomRestaurant(ResultViewModel model)
        {
            model.RestaurantResult = randomRestaurant(model.Restuarants);
            return View("ResultTemp", model);
        }

        public ActionResult RandomActivity(ResultViewModel model)
        {
            model.ActivityResult = randomActivity(model.Activities);
            return View("ResultTemp", model);
        }


        Activity randomActivity(List<Activity> activities)
        {
            Random rnd = new Random();
            int Random = rnd.Next(0, activities.Count);
            return activities[Random];
        }

        Restaurant randomRestaurant(List<Restaurant> restaurants)
        {
            Random rnd = new Random();
            int Random = rnd.Next(0, restaurants.Count);
            return restaurants[Random];
        }
    }
}