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
            @"https://app.ticketmaster.com/discovery/v2/events.json?city=Grand%20Rapids&state=MI&countryCode=US&apikey=oIsA0vq6NW2LaHLqAg6ySW7LZKblGGHT";



        public ActionResult Index()
        {

            JObject response = PerformRequest(url);


            foreach (var activity in response["_embedded"]["events"].ToList())
            {


                Activity newActivity = new Activity();
                dynamic activityDyn = JObject.Parse(activity.ToString());

                newActivity.Venue = activityDyn.name;

                dynamic classifications = JObject.Parse(activityDyn["classifications"].ToString());

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