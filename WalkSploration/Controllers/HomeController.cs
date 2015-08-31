using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;   
using WalkSploration.Models;
using System.Net;
using System.Web.Script.Serialization;

namespace WalkSploration.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}


        public ActionResult Index(string time)
        {
            var inputTime = Convert.ToInt32(time);
            var timeHalf = ((inputTime + .20f) / 2) * 1.1f;

            //create and initialize two floating point variables
            //float timeWhole = 0;
            //float timeHalf = 0;
            //cast time to float
            //bool checkInput = Int32.TryParse(time, out timeWhole);
            //timeHalf = ((timeWhole + .20f) / 2) * 1.1f;

            if (time == null)
            {
                ModelState.AddModelError("", "Unable to process request. Please ensure that a valid time has been entered.");
            }
            else if (inputTime > 60)
            {
                ModelState.AddModelError("", "Please enter a time equal to or less than 60 minutes.");
            }
            else if (inputTime <= 0)
            {
                ModelState.AddModelError("", "Please enter a time equal to or greater than 1.");
            }


            return View(timeHalf);
        }        
        
        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}