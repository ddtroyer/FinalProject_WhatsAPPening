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
        public int Number { get; set; }
        public int numPeople { get; set; }

        [DisplayName("Budget")]
        [Required(ErrorMessage = "Please enter a budget.")]
        public int Budget { get; set; }

        [DisplayName("Cuisine Type")]
        [Required(ErrorMessage = "Please select a cuisine type.")]
        public string CuisineType { get; set; }

        //[DisplayName("Number of People")]             

        [DisplayName("Zipcode")]
        [Required(ErrorMessage = "Please enter your zipcode.")]
        public int Zipcode { get; set; }

    }
}