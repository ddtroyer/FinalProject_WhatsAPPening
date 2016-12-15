using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YelpAPI;
using System.Net;
using System.Security.Cryptography.Xml;
using System.Text;
using Newtonsoft.Json.Linq;
using SimpleOAuth;
using FinalProject_WhatsAPPening.Models;

namespace FinalProject_WhatsAPPening.Controllers
{
    public class TicketmasterController : Controller
    {
        public const string CONSUMER_KEY = "oIsA0vq6NW2LaHLqAg6ySW7LZKblGGHT";
        public const string CONSUMER_SECRET = "AEizpRfGwjhzvU5g";

        public const string url =
            @"https://app.ticketmaster.com/discovery/v2/events.json?city=Grand%20Rapids&state=MI&countryCode=US&startDateTime=2016-12-13T00:00:00Z&apikey=oIsA0vq6NW2LaHLqAg6ySW7LZKblGGHT";


        public ActionResult Index()
        {
            JObject response = PerformRequest(url);


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
                if (activityDyn["priceRanges"] != null)
                {
                    dynamic priceRange = activityDyn["priceRanges"];
                    decimal min = priceRange[0].min;
                    decimal max = priceRange[0].max;
                    decimal avg = ((min + max)/2);
                    newActivity.PricePerPerson = avg.ToString();

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

            }
            return View();

        }
        private static JObject PerformRequest(string baseURL)
        {

            var request = WebRequest.Create(baseURL);
            request.Method = "GET";
            request.Credentials = CredentialCache.DefaultCredentials;

            ((HttpWebRequest)request).Accept = @"text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            ((HttpWebRequest)request).UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.99 Safari/537.36";
             HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            var stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

            return JObject.Parse(stream.ReadToEnd());
        }
    }
}