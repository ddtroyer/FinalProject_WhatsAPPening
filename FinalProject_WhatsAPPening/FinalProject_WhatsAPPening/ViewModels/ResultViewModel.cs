using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalProject_WhatsAPPening.Models;
using Microsoft.Owin.Security;
using System.ComponentModel.DataAnnotations;


namespace FinalProject_WhatsAPPening.Models
{
    public class ResultViewModel
    {
       
        
        public Activity ActivityResult { get; private set; }
        public Restaurant RestaurantResult { get; private set; }


        public List<Activity> Activities { get; set; }
        public List<Restaurant> Restuarants { get; set; }

        public void SetRestaurant(Restaurant RestaurantValue)
        {
            RestaurantResult = RestaurantValue;
        }

        public void SetActivity(Activity ActivityValue)
        {
            ActivityResult = ActivityValue;
        }

        public void SetRandomRestaurant()
        {
            if (Restuarants.Count > 0)
            {
                Random rnd = new Random();
                int random = rnd.Next(0, this.Restuarants.Count);
                this.RestaurantResult = this.Restuarants[random];
            }
            else
            {
                this.RestaurantResult = new Restaurant()
                {
                    Name = "No Restaurant Found"
                };
            }
        }

        public void SetRandomActivity()
        {

            if (this.Activities.Count > 0)
            {
                Random rnd = new Random();
                int random = rnd.Next(0, this.Activities.Count);
                this.ActivityResult = this.Activities[random];
            }
            else
            {
                this.ActivityResult = new Activity()
                {
                    Venue = "No Activity Found",
                    PricePerPerson = "0.00"
                };

            }


        }
    }

}
