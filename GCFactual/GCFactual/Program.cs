using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactualDriver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GCFactual
{
    class Program
    {
        public const string OATHKEY = "FxpykhYWyCQ3Gsm58GhTVpnWNeY66aB1lwwXkV3g";
        public const string OATHSECRET = "9xNJ1Swu3nKKyReU668knmNGGZqqhAtF1gnOQEQW";


        static void Main(string[] args)
        {
            Random rnd = new Random();
            int gcRndInt = rnd.Next(0, 50);

            Factual gcFactual = new Factual(OATHKEY,
                OATHSECRET);
            string v = gcFactual.Fetch("restaurants", new Query()
                .Field("locality")
                .Equal("Grand Rapids")
                .Field("region")
                .Equal("MI")
                .Field("price")
                .Equal("3")
                .Offset(0)
                .Limit(40));

            
            var gcJObject = JObject.Parse(v);

            
            foreach (var s in gcJObject["response"]["data"].ToList())
            {
                ;
                
                dynamic info = JObject.Parse(s.ToString());

                string name = info.name;
                Console.WriteLine("Name: " + name);

                string address = info.address;
                Console.WriteLine("Address: " + address);

                string postcode = info.postcode;
                Console.WriteLine("Zipcode: " + postcode);

                string price = info.price;
                Console.WriteLine("Price: " + price);

                Console.WriteLine("Cuisine Types:");
                if (info.cuisine != null)
                {
                    var cuisine = info.cuisine;
                    foreach (var cusineVar in cuisine)
                    {
                        Console.WriteLine(cusineVar.ToString());
                    }
                }

                string alcohol = info.alcohol;
                Console.WriteLine("Alcohol Served: " + alcohol);

                Console.WriteLine("Hours:");
                if (info.hours != null)
                {
                    var hours = info.hours;
                    foreach (var hoursVar in hours)
                    {
                        Console.WriteLine(hoursVar);
                        
                    }
                }


                Console.ReadLine();
              
            }


            //factual.Fetch("places",  new Query().Field("category_ids").Includes("347").Limit(100);
        }
    }
}
