using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject_WhatsAPPening.Models
{
    public class Request
    {
        [Required(ErrorMessage = "Please Enter A Budget")]
        public int Budget { get; set; }

        [Required(ErrorMessage = "Please select a Cuisine Type")]
        public string CusineType { get; set; }
  
        //public int ZipCode { get; set; }      
        
    }
}