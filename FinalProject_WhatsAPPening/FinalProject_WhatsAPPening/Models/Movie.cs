using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_WhatsAPPening.Models
{
    //Movie class will be used in Results class
    public class Movie
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public string Length { get; set; }
        public string ImageURL { get; set; }
        public string Theatre { get; set; }
        public string TheatreAddress { get; set; }
        public int TheatreZipCode { get; set; }
    }
}