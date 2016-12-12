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
        //Assigning keys to shorter variable names
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
            //variables assigned values based on user values entered in the form (# of people, Budget, and Cuisine Type)
            Request dataRequest = new Request();
            dataRequest.Budget = int.Parse(form["Budget"]);
            dataRequest.CuisineType = form["foodDropdown"];
            dataRequest.numPeople = int.Parse(form["Number"]);

            ViewBag.Message = "Results page.";
            //'price' variable is assigned to 1,2,3,or 4. This value is created by methods in the QueryHelper class
            int price = QueryHelper.RestaurantPrice(dataRequest.Budget, dataRequest.numPeople);

            //New FactualDriver object being created using the variable names previously assigned to keys
            Factual Factual = new Factual(OATHKEY,OATHSECRET);
            string data = Factual.Fetch("restaurants", new Query() //The Fetch method parameters require a table name and a new query.
                .Field("locality")
                .Equal("Grand Rapids") //'locality' field set to 'Grand Rapids'
                .Field("region")
                .Equal("MI") //'region' field set to 'MI'
                .Field("price")
                .Equal(price.ToString()) //'price' field set by 'int price' variable (int is then converted to a string) 
                .Field("cuisine")
                .Equal(dataRequest.CuisineType.ToLower()) //'cuisine' field set by 'dataRequest.CuisineType' variable (determined by form dropdown menu)
                .Offset(0)
                .Limit(40));

            var jData = JObject.Parse(data); //'data' is being Parsed from string to JObject type

            List<Restaurant> restaurants = new List<Restaurant>(); //initializing a new list of resaurants

            foreach (var gcVar in jData["response"]["data"].ToList())
            {
                Restaurant restaurant = new Restaurant(); //Each item in 'restaurants' list is initialized as a new 'restaurant'
                dynamic restVar = JObject.Parse(gcVar.ToString()); //'restVar' is created and holds the properties of a Resaurant object (these properties are from the Restaurant class: name, address, etc...)

                string tString = System.DateTime.Now.DayOfWeek.ToString().ToLower(); //'tString' variable assigned value based on day of the week
                //Used for finding hours of operation for restaurants for the current day of the week

                if (restVar["hours"] != null)
                {
                    //TODO Format restaurant hours to display correctly
                    var hours = restVar["hours"][tString];
                    restaurant.Hours = hours.ToString(); 
                }
                //The new Restaurant object named 'restaurant' has its properties assigned values. These values are taken from the 'restVar' variable
                restaurant.Name = restVar.name;
                restaurant.PriceRange = (PriceRange)restVar.price; //'PriceRange' is an enum found in the Restaurant class
                restaurant.Address = restVar.address;
                restaurant.ZipCode = restVar.postcode;

                restaurant.CuisineTypes = new List<string>(); //Many restaurants serve multiple cuisine types so a list is created to display these types
                foreach (var cuisineVar in restVar.cuisine)
                {
                    restaurant.CuisineTypes.Add(cuisineVar.ToString()); //The foreach loop iterates through the multiple types and adds them to the 'restaurant.CuisineTypes' list
                }

                restaurant.Description = new List<string>(); //Like the cuisine types list and foreach loop, but for restaurant description
                foreach (var desVar in restVar.category_labels)
                {
                    restaurant.Description.Add(desVar.ToString());
                }
                
                restaurants.Add(restaurant); //Now the 'restaurant' is added to the list named 'restaurants' and the foreach loop repeats this process (starting at line 57)

            }
            List<Activity> activities = new List<Activity>();
            using (DBActivity db = new DBActivity())
            {
                foreach (var activity in db.Activities.Where(P <= (dataRequest.Budget * .5 / dataRequest.numPeople)))
                {
                    Activity newActivity = new Activity();
                    newActivity.Category = activity.Category;
                    newActivity.City = activity.City;
                    newActivity.DaysOpen = activity.DaysOpen;
                    newActivity.Id = activity.Id;
                    newActivity.Link = activity.Link;
                    newActivity.PhoneNumber = activity.PhoneNumber;
                    newActivity.PricePerPerson = activity.PricePerPerson;
                    newActivity.State = activity.State;
                    newActivity.StreetAddress = activity.StreetAddress;
                    newActivity.TimesOpen = activity.TimesOpen;
                    newActivity.Venue = activity.Venue;
                    newActivity.Zip = activity.Zip;

                    activities.Add(newActivity);
                }
            }

            Random rnd = new Random();
            int restInt = rnd.Next(0, restaurants.Count());
            int actInt = rnd.Next(0, activities.Count());

            Restaurant modelRestaurant = restaurants[restInt];
            Activity modelActivity = activities[actInt];

            ResultViewModel result = new ResultViewModel();

            result.RestaurantResult = modelRestaurant;
            result.ActivityResult = modelActivity;
            return View("ResultTemp", result);

            //return View("Activity", activities); DELETE THIS?
            //return View("RestaurantsTemp",restaurants); DELETE THIS?

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}