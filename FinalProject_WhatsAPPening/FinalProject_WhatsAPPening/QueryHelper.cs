using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_WhatsAPPening
{
    public class QueryHelper
    {
        public static int RestaurantPrice(int budget, int? people) //the budget parameter must be entered. People is set by default if that parameter is not entered
        {
            if (people == null)
            {
                people = 2;     //If number of people is not entered by the user, number of peeople is set to 2 by default
            }

            double budgetPerPerson = (double) (budget*.5/people);   //Takes half of the total budget for the resaurant. Assumes the other half will go towards 'Activity'

            if (budgetPerPerson <= 10)
            {
                return 1;
            }
            else if (budgetPerPerson <= 30)
            {
                return 2;
            }
            else if (budgetPerPerson <= 60)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }   //These values of 1, 2, 3, or 4 determine the value assigned to 'int price' variable in the HomeController
    }
}