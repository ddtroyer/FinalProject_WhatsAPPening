using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_WhatsAPPening.Models
{
    //Movie class will be used in Results class
    public class Activity
    {
        public string Id { get; set; }

        public string Category { get; set; }

        public string ImageUrl { get; set; }

        public string Link { get; set; }

        public string Venue { get; set; }

        public int PricePerPerson { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int Zip { get; set; }

        public string PhoneNumber { get; set; }

        public string MovieName { get; set; }

        public string MovieDescription { get; set; }

        public DateTime StartTime { get; set; }

        public string LengthOfTime { get; set; }

        public DateTime DaysOpen { get; set; }

        public DateTime TimesOpen { get; set; }
    }
}