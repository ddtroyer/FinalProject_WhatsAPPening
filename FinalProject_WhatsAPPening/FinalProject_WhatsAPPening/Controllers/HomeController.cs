using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject_WhatsAPPening.Models;
using FactualDriver;


namespace FinalProject_WhatsAPPening.Controllers
{

    public class HomeController : Controller
    {
        public const string OATHKEY = "FxpykhYWyCQ3Gsm58GhTVpnWNeY66aB1lwwXkV3g";
        public const string OATHSECRET = "9xNJ1Swu3nKKyReU668knmNGGZqqhAtF1gnOQEQW";
        //GET
        public ActionResult Index()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            Request dataRequest = new Request();
            dataRequest.Budget = int.Parse(form["Budget"]);
            dataRequest.CuisineType = form["foodDropdown"];
            dataRequest.numPeople = int.Parse(form["numPeople"]);

            ViewBag.Message = "Results page.";
            int price = QueryHelper.RestaurantPrice(dataRequest.Budget, dataRequest.numPeople);

            Factual Factual = new Factual(OATHKEY,OATHSECRET);
            string v = Factual.Fetch("restaurants", new Query()
                .Field("locality")
                .Equal("Grand Rapids")
                .Field("region")
                .Equal("MI")
                .Field("price")
                .Equal(price.ToString())
                .Field("cuisine")
                .Equal(dataRequest.CuisineType.ToLower())
                .Offset(0)
                .Limit(40));

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}