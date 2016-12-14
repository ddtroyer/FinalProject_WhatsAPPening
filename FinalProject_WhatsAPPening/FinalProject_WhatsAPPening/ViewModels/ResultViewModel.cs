using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject_WhatsAPPening.Models;
using Microsoft.Owin.Security;


namespace FinalProject_WhatsAPPening.Models
{
    public class ResultViewModel
    {
        public Activity ActivityResult { get; set; }
        public List<Activity> Activities { get; set; }

        public Restaurant RestaurantResult { get; set; }
        public List<Restaurant> Restuarants { get; set; }

        

        public ResultViewModel Mirror
        {
            get
            {
                ResultViewModel rvm = new ResultViewModel();
               
                rvm.ActivityResult = this.ActivityResult;
                rvm.Activities = this.Activities;
                rvm.RestaurantResult = this.RestaurantResult;
                rvm.Restuarants = this.Restuarants;
                return rvm;
            }
           
        }

    }
}