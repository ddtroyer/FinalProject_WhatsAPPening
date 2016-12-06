using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FinalProject_WhatsAPPening.Models
{
    public class Restaurant
    {
        [DisplayName("Cuisine")]
        public string CuisineType { get; set; }

        [DisplayName("Price Range")]
        public int PriceRange { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Street Address")]
        public string Address { get; set; }

        [DisplayName("Zip")]
        public int ZipCode { get; set; }      
    }
}