using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_WhatsAPPening
{
    public class QueryHelper
    {
        public static int RestaurantPrice(int budget, int? people)
        {
            if (people == null)
            {
                people = 2;
            }

            double budgetPerPerson = (double) (budget*.5/people);

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
        }
    }
}