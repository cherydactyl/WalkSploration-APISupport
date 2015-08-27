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

namespace WalkSploration.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchIndex() {
            return View();
        }
        
        //Get Point of Interset
        public ActionResult SearchIndex(float? latitude, float? longitude)
        {
            ViewBag.InputLatitude = latitude;
            ViewBag.InputLongitude = longitude;

            if (latitude == null || longitude == null)
            {
                ModelState.AddModelError("", "Unable to process request. Please ensure that the correct latitude and longitude have been entered.");
            }

            PointOfInterest poi = db.PointsofInterest.Find(id);
            if (poi == null)
            {
                return HttpNotFound();
            }
            
            
            return View(poi);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}