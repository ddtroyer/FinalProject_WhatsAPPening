using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using FinalProject_WhatsAPPening.Models;
using FactualDriver;
using Newtonsoft.Json.Linq;
using System;
using YelpAPI;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Text;
using Newtonsoft.Json.Linq;
using SimpleOAuth;
using FinalProject_WhatsAPPening.Models;

namespace FinalProject_WhatsAPPening.Controllers
{

    public class HomeController : Controller
    {
        //Assigning keys to shorter variable names
        public const string OATHKEY = "FxpykhYWyCQ3Gsm58GhTVpnWNeY66aB1lwwXkV3g";
        public const string OATHSECRET = "9xNJ1Swu3nKKyReU668knmNGGZqqhAtF1gnOQEQW";
        public const string TMBaseURL = @"https://app.ticketmaster.com/discovery/v2/events.json?";
        public const string TMAPI = "oIsA0vq6NW2LaHLqAg6ySW7LZKblGGHT";
        //GET
        public ActionResult Index()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            //Variables assigned values based on user values entered in the form (# of people, Budget, and Cuisine Type)
            Request dataRequest = new Request();
            ResultViewModel result = new ResultViewModel();
            dataRequest.numPeople = int.Parse(form["numPeople"]);
            dataRequest.Budget = int.Parse(form["Budget"]);
            dataRequest.CuisineType = form["categoryDropdown"];
            dataRequest.Zipcode = form["Zipcode"];

            ViewBag.Message = "Results page.";
            //'price' variable is assigned to 1,2,3,or 4. This value is created by methods in the QueryHelper class
            int price = QueryHelper.RestaurantPrice(dataRequest.Budget, dataRequest.numPeople);

            //New FactualDriver object being created using the variable names previously assigned to keys
            Factual Factual = new Factual(OATHKEY, OATHSECRET);
            string data = null;
            try
            {
                data = Factual.Fetch("restaurants",
                    new Query() //The Fetch method parameters require a table name and a new query
                        .Field("price")
                        .Equal(price.ToString())
                        //'price' field set by 'int price' variable (int is then converted to a string) 
                        .Field("cuisine")
                        .Equal(dataRequest.CuisineType.ToLower())
                        //'cuisine' field set by 'dataRequest.CuisineType' variable (determined by form dropdown menu)
                        .Field("postcode")
                        .Equal(dataRequest.Zipcode)
                        .Offset(0)
                        .Limit(40));
            }
            catch
            {
                data = "{Error: 'Please try again'}";
            }

            var jData = JObject.Parse(data); //'data' is being Parsed from string to JObject type

            List<Restaurant> restaurants = new List<Restaurant>(); //Initializing a new list of resaurants
            //Each item in 'restaurants' list is initialized as a new 'restaurant'

            if (jData["Error"] == null)
            {
                foreach (var gcVar in jData["response"]["data"].ToList())
                {
                    Restaurant restaurant = new Restaurant();
                    dynamic restVar = JObject.Parse(gcVar.ToString());
                    //'restVar' is created and holds the properties of a Resaurant object (these properties are from the Restaurant class: name, address, etc...)

                    string tString = System.DateTime.Now.DayOfWeek.ToString().ToLower();
                    //'tString' variable assigned value based on day of the week
                    //Used for finding hours of operation for restaurants for the current day of the week

                    if (restVar["hours"] != null)
                    {
                        //TODO Format restaurant hours to display correctly
                        var hours = restVar["hours"][tString];
                        if (hours != null)
                        {
                            restaurant.Hours = hours.ToString();
                        }

                    }
                    //The new Restaurant object named 'restaurant' has its properties assigned values. These values are taken from the 'restVar' variable
                    restaurant.Name = restVar.name;
                    restaurant.PriceRange = (PriceRange) restVar.price;
                    //'PriceRange' is an enum found in the Restaurant class
                    restaurant.Address = restVar.address;
                    restaurant.ZipCode = restVar.postcode;
                    restaurant.Website = restVar.website;

                    restaurant.CuisineTypes = new List<string>();
                    //Many restaurants serve multiple cuisine types so a list is created to display these types
                    foreach (var cuisineVar in restVar.cuisine)
                    {
                        restaurant.CuisineTypes.Add(cuisineVar.ToString());
                        //The foreach loop iterates through the multiple types and adds them to the 'restaurant.CuisineTypes' list
                    }

                    restaurant.Description = new List<string>();
                    //Just like the CuisineTypes list foreach loop, but for restaurant description
                    foreach (var desVar in restVar.category_labels)
                    {
                        restaurant.Description.Add(desVar.ToString());
                    }

                    restaurants.Add(restaurant);
                    //Now the 'restaurant' is added to the list named 'restaurants' and the foreach loop repeats this process (starting at line 57)

                }
            }


            List<Activity> activities = new List<Activity>();

            string zipcode = form["Zipcode"];
            string qString = TMQueryString(zipcode, "10");

            List<Activity> tempActivity = ActivitiesRequest(qString);
                

            foreach (Activity activity in tempActivity)
            {
                activities.Add(activity);
            }

            if (zipcode.Substring(0, 3) == "495")
            {
                using (DBActivity db = new DBActivity())
                {
                    foreach (var activity in db.Activities)
                    {
                        if (activity.PricePerPerson != null)
                            if (double.Parse(activity.PricePerPerson) <=
                                (dataRequest.Budget*.5/dataRequest.numPeople))
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
                }
 
            }

            Random rnd = new Random();

            if (restaurants.Count > 0)
            {
                int restInt = rnd.Next(0, restaurants.Count());
                result.RestaurantResult = restaurants[restInt];
            }
            else
            {
                result.RestaurantResult = new Restaurant()
                {
                    Name = "No Restaurant Found"
                };
            }

            if (activities.Count > 0)
            {
                int actInt = rnd.Next(0, activities.Count());
                result.ActivityResult = activities[actInt];
            }
            else
            {
                result.ActivityResult = new Activity()
                {
                    Venue = "No Activity Found",
                    PricePerPerson = "$0.00"
                };

            }
            return View("ResultTemp", result);
        }

        public
            ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public List<Activity> ActivitiesRequest(string QueryURL)
        {

            JObject response = PerformRequest(QueryURL);
            List<Activity> activities = new List<Activity>();

            foreach (var activity in response["_embedded"]["events"].ToList())
            {




                dynamic activityDyn = JObject.Parse(activity.ToString());
                Activity newActivity = new Activity();

                newActivity.Venue = activityDyn.name;
                newActivity.Link = activityDyn.url;
                if (activityDyn["dates"]["start"]["localTime"] != null)
                {
                    string dateTime = activityDyn["dates"]["start"]["localTime"];
                    DateTime hoursOpen = DateTime.Parse(dateTime);
                    newActivity.TimesOpen = hoursOpen.ToString("h:mm tt");
                }

                if (activityDyn["classifications"] != null)
                {
                    dynamic classifications = activityDyn["classifications"];
                    dynamic genre = classifications[0]["genre"];
                    dynamic segment = classifications[0]["segment"];
                    string segName = segment.name;
                    string genreName = genre.name;

                    if (!String.IsNullOrWhiteSpace(segName))
                    {
                        newActivity.Category = segName + " - " + genreName;
                    }
                    else
                    {
                        newActivity.Category = genreName;
                    }

                }

                if (activityDyn["priceRanges"] != null)
                {
                    dynamic priceRange = activityDyn["priceRanges"];
                    decimal min = priceRange[0].min;
                    decimal max = priceRange[0].max;
                    decimal avg = ((min + max) / 2);
                    newActivity.PricePerPerson = avg.ToString();

                }

                if (activityDyn["_embedded"]["venues"] != null)
                {
                    dynamic venues = activityDyn["_embedded"]["venues"];
                    newActivity.Venue += " at " + venues[0].name;
                    newActivity.Zip = venues[0].postalCode;
                    newActivity.City = venues[0]["city"]["name"];
                    newActivity.State = venues[0]["state"]["stateCode"];
                    newActivity.StreetAddress = venues[0]["address"]["line1"];

                    if (venues[0]["boxOfficeInfo"] != null)
                    {
                        dynamic boxOffice = venues[0]["boxOfficeInfo"];
                        string phoneNumber = boxOffice.phoneNumberDetail;
                        newActivity.PhoneNumber = phoneNumber.Substring(phoneNumber.Length - 14);
                    }

                }

                activities.Add(newActivity);
            }

            return activities;
        }

        private static JObject PerformRequest(string baseURL)
        {

            var request = WebRequest.Create(baseURL);
            request.Method = "GET";
            request.Credentials = CredentialCache.DefaultCredentials;

            ((HttpWebRequest) request).Accept =
                @"text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            ((HttpWebRequest) request).UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.99 Safari/537.36";
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();

            var stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

            return JObject.Parse(stream.ReadToEnd());




        }

        public string TMQueryString(string postalCode, string radius = null)
        {
            if (radius == null)
                radius = "5";

            string today = String.Format("{0:s}", DateTime.Today);

            StringBuilder returnString = new StringBuilder();
            returnString.Append(TMBaseURL);
            returnString.Append("startDateTime=");
            returnString.Append(today + "Z&");
            returnString.Append("postalCode=");
            returnString.Append(postalCode + "&");
            returnString.Append("radius=");
            returnString.Append(radius + "&");
            returnString.Append("apikey=");
            returnString.Append(TMAPI);

            return returnString.ToString();

        }

    }
}