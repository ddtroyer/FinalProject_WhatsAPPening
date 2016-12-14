using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject_WhatsAPPening.Models
{
    public class Request
    {   //This class represents the reqeust form
        [DisplayName("Number of People")]
        [Required(ErrorMessage = "Please Enter the Number of People")]
        [Range(1, 10, ErrorMessage = "Number must be between 1 and 10")]
        public int numPeople { get; set; }

        [DisplayName("Budget")]
        [Required(ErrorMessage = "Please Enter A Budget")]
        public int Budget { get; set; }

        [DisplayName("Cuisine Type")]
        [Required(ErrorMessage = "Please select a Cuisine Type")]
        public string CuisineType { get; set; }

        [DisplayName("Activity Category")]
        [Required(ErrorMessage = "Please select an Activity Category.")]
        public string Category { get; set; }

        [DisplayName("Zipcode")]
        [RegularExpression(@"^\d{5}?$", ErrorMessage = "Invalid Zip Code")]
        public string Zipcode { get; set; }
    }
}