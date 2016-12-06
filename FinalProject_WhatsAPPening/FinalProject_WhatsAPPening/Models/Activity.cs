using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FinalProject_WhatsAPPening.Models
{
    //Movie class will be used in Results class
    public class Activity
    {
        public string Id { get; set; }

        [DisplayName("Category")]
        public string Category { get; set; }

        public string ImageUrl { get; set; }

        [DisplayName("Link")]
        public string Link { get; set; }

        [DisplayName("Venue")]
        public string Venue { get; set; }

        [DisplayName("Price Per Person")]
        public int PricePerPerson { get; set; }

        [DisplayName("Street Address")]
        public string StreetAddress { get; set; }

        [DisplayName("City")]
        public string City { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        [DisplayName("Zip")]
        public int Zip { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Title")]
        public string MovieName { get; set; }

        [DisplayName("Description")]
        public string MovieDescription { get; set; }

        [DisplayName("Start Time")]
        public DateTime StartTime { get; set; }

        [DisplayName("Length Of Time")]
        public string LengthOfTime { get; set; }

        [DisplayName("Days Open")]
        public DateTime DaysOpen { get; set; }

        [DisplayName("Times Open")]
        public DateTime TimesOpen { get; set; }
    }
}