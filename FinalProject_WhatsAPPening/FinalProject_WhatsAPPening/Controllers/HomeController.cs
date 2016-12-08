using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject_WhatsAPPening.Models;
using FactualDriver;
using Newtonsoft.Json.Linq;


namespace FinalProject_WhatsAPPening.Controllers
{

    public class HomeController : Controller
    {
        public const string OATHKEY = "FxpykhYWyCQ3Gsm58GhTVpnWNeY66aB1lwwXkV3g";
        public const string OATHSECRET = "9xNJ1Swu3nKKyReU668knmNGGZqqhAtF1gnOQEQW";
        //GET
        public ActionResult Index()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            Request dataRequest = new Request();
            dataRequest.Budget = int.Parse(form["Budget"]);
            dataRequest.CuisineType = form["foodDropdown"];
            dataRequest.numPeople = int.Parse(form["Number"]);

            ViewBag.Message = "Results page.";
            int price = QueryHelper.RestaurantPrice(dataRequest.Budget, dataRequest.numPeople);

            Factual Factual = new Factual(OATHKEY,OATHSECRET);
            string data = Factual.Fetch("restaurants", new Query()
                .Field("locality")
                .Equal("Grand Rapids")
                .Field("region")
                .Equal("MI")
                .Field("price")
                .Equal(price.ToString())
                .Field("cuisine")
                .Equal(dataRequest.CuisineType.ToLower())
                .Offset(0)
                .Limit(40));

            var jData = JObject.Parse(data);

            List<Restaurant> restaurants = new List<Restaurant>();

            foreach (var gcVar in jData["response"]["data"].ToList())
            {
                Restaurant restaurant = new Restaurant();
                dynamic restVar = JObject.Parse(gcVar.ToString());

                string tString = System.DateTime.Now.DayOfWeek.ToString().ToLower();

                if (restVar["hours"] != null)
                {
                    var hours = restVar["hours"][tString];
                    restaurant.Hours = hours.ToString(); 
                }

                restaurant.Name = restVar.name;
                restaurant.PriceRange = (PriceRange)restVar.price;
                restaurant.Address = restVar.address;
                restaurant.ZipCode = restVar.postcode;

                restaurant.CuisineTypes = new List<string>();
                foreach (var cuisineVar in restVar.cuisine)
                {
                    restaurant.CuisineTypes.Add(cuisineVar.ToString());
                }

                restaurant.Description = new List<string>();
                foreach (var desVar in restVar.category_labels)
                {
                    restaurant.Description.Add(desVar.ToString());
                }


                restaurants.Add(restaurant);

            }

           

            return View("RestaurantsTemp",restaurants);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}