using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject_WhatsAPPening.Models
{
    public class Request
    {
        [DisplayName("Number of People")]
        [Required(ErrorMessage = "Please Enter the Number of People")]
        public int Number { get; set; }

        [DisplayName("Budget")]
        [Required(ErrorMessage = "Please Enter A Budget")]
        public int Budget { get; set; }

        [DisplayName("Cuisine Type")]
        [Required(ErrorMessage = "Please select a Cuisine Type")]
        public string CuisineType { get; set; }
  
        //public int ZipCode { get; set; }      
        
    }
}