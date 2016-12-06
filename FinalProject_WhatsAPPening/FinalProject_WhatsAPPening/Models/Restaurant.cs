using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_WhatsAPPening.Models
{
    public class Restaurant
    {
        public string CuisineType { get; set; }

        public int PriceRange { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public int ZipCode { get; set; }      
    }
}