<<<<<<< HEAD
<<<<<<< HEAD
﻿using System;
using Google.GData.Client;          //Install-Package Google.GData.Client, Install-Package Newtonsoft.Json
=======
﻿using Google.GData.Client;          //Install-Package Google.GData.Client, Install-Package Newtonsoft.Json
>>>>>>> 38b502a27588535851d97ce9a40e1963534b992a
=======
﻿using Google.GData.Client;          //Install-Package Google.GData.Client, Install-Package Newtonsoft.Json
>>>>>>> 38b502a27588535851d97ce9a40e1963534b992a
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
<<<<<<< HEAD
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;   
using WalkSploration.Models;
using System.Net;
<<<<<<< HEAD
<<<<<<< HEAD
using System.Web.Script.Serialization;
using System.IO;
=======
=======
>>>>>>> 38b502a27588535851d97ce9a40e1963534b992a
=======
using WalkSploration.Models;
using System.Net;
using System;
using System.IO;
>>>>>>> e94b2b58cd564a29986348a68ca648856daea822
<<<<<<< HEAD
>>>>>>> 38b502a27588535851d97ce9a40e1963534b992a
=======
>>>>>>> 38b502a27588535851d97ce9a40e1963534b992a

namespace WalkSploration.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}


<<<<<<< HEAD
        //public ActionResult Index(string time)
=======
        public ActionResult Index(string time)
        {
<<<<<<< HEAD
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
=======
            //Grand Circus 42.3347, -83.0497
            getPlaces(42.3347, -83.0497);
            return View();
            
>>>>>>> e94b2b58cd564a29986348a68ca648856daea822
        }

        //Commented out on 8.27.15 to incorporate code with Vaneitta

        ////Get Point of Interset
        //public ActionResult SearchIndex(float? latitude, float? longitude)
>>>>>>> 38b502a27588535851d97ce9a40e1963534b992a
        //{
        //    var inputTime = Convert.ToInt32(time);
        //    var timeHalf = ((inputTime + .20f) / 2) * 1.1f;

        //    //create and initialize two floating point variables
        //    //float timeWhole = 0;
        //    //float timeHalf = 0;
        //    //cast time to float
        //    //bool checkInput = Int32.TryParse(time, out timeWhole);
        //    //timeHalf = ((timeWhole + .20f) / 2) * 1.1f;

        //    if (time == null)
        //    {
        //        ModelState.AddModelError("", "Unable to process request. Please ensure that a valid time has been entered.");
        //    }
        //    else if (inputTime > 60)
        //    {
        //        ModelState.AddModelError("", "Please enter a time equal to or less than 60 minutes.");
        //    }
        //    else if (inputTime <= 0)
        //    {
        //        ModelState.AddModelError("", "Please enter a time equal to or greater than 1.");
        //    }


        //    return View(timeHalf);
        //}

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

        //helper functions here

        public ActionResult Index()
        {
            //Grand Circus 42.3347, -83.0497
            getPlaces(42.3347, -83.0497);
            return View();

        }

        public List<PointOfInterest> getPlaces(double latitude, double longitude)
        {
            //create query
            //build ("https://maps.googleapis.com/maps/api/place/nearbysearch/output?" + parameters)
            //OR (less data) 
            string URI = "https://maps.googleapis.com/maps/api/place/radarsearch/json?";
            //add parameters
            //key
            URI += "?key=" + (new Secrets()).GoogleAPIServerKey;
            //location
            URI += "location=" + latitude.ToString() + "," + longitude.ToString() + "&";
            //radius; 2 miles ~= 3200 meters; google requires radiun in meters, max 50,000
            URI += "radius=3200&";
            //types; start with "park" and possibly add more later
            //see https://developers.google.com/places/supported_types for list of types
            URI += "types=park";

            //request processing
            WebRequest request = WebRequest.Create(URI);
            request.Method = "GET";
            request.ContentType = "application/json";
            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();


            //create a new list
            List<PointOfInterest> PoIs = new List<PointOfInterest>();

            //iterate over the json and parse into PointsOfInterest, placing each in list


            //return processed list
            return PoIs;
        }

<<<<<<< HEAD
=======

        //helper functions here
        public List<PointOfInterest> getPlaces(double latitude, double longitude)
        {
            //create query
            //build ("https://maps.googleapis.com/maps/api/place/nearbysearch/output?" + parameters)
            //OR (less data) 
            string URI = "https://maps.googleapis.com/maps/api/place/radarsearch/json?";
            //add parameters
            //key
            URI += "?key=" + (new Secrets()).GoogleAPIServerKey;
            //location
            URI += "location=" + latitude.ToString() + "," + longitude.ToString() + "&";
            //radius; 2 miles ~= 3200 meters; google requires radiun in meters, max 50,000
            URI += "radius=3200&";
            //types; start with "park" and possibly add more later
            //see https://developers.google.com/places/supported_types for list of types
            URI += "types=park";

            //request processing

            WebRequest request = WebRequest.Create(URI);
            request.Method = "GET";
            request.ContentType = "application/json";
            WebResponse response = request.GetResponse();

            Stream dataStream = processHttpJSonReq(URI).GetResponseStream();       // ???


            //create a new list
            List<PointOfInterest> PoIs = new List<PointOfInterest>();       //start with empty list

            //iterate over the json and parse into PointsOfInterest, placing each in list
            

            //return processed list
            return PoIs;
        }

        WebResponse processHttpJSonReq(string URI)
        {
            WebRequest request = WebRequest.Create(URI);
            request.Method = "GET";
            request.ContentType = "application/json";
            WebResponse response = request.GetResponse();
            return response;
        }

<<<<<<< HEAD
>>>>>>> 38b502a27588535851d97ce9a40e1963534b992a
=======

        //helper functions here
        public List<PointOfInterest> getPlaces(double latitude, double longitude)
        {
            //create query
            //build ("https://maps.googleapis.com/maps/api/place/nearbysearch/output?" + parameters)
            //OR (less data) 
            string URI = "https://maps.googleapis.com/maps/api/place/radarsearch/json?";
            //add parameters
            //key
            URI += "?key=" + (new Secrets()).GoogleAPIServerKey;
            //location
            URI += "location=" + latitude.ToString() + "," + longitude.ToString() + "&";
            //radius; 2 miles ~= 3200 meters; google requires radiun in meters, max 50,000
            URI += "radius=3200&";
            //types; start with "park" and possibly add more later
            //see https://developers.google.com/places/supported_types for list of types
            URI += "types=park";

            //request processing

            WebRequest request = WebRequest.Create(URI);
            request.Method = "GET";
            request.ContentType = "application/json";
            WebResponse response = request.GetResponse();

            Stream dataStream = processHttpJSonReq(URI).GetResponseStream();       // ???


            //create a new list
            List<PointOfInterest> PoIs = new List<PointOfInterest>();       //start with empty list

            //iterate over the json and parse into PointsOfInterest, placing each in list
            

            //return processed list
            return PoIs;
        }

        WebResponse processHttpJSonReq(string URI)
        {
            WebRequest request = WebRequest.Create(URI);
            request.Method = "GET";
            request.ContentType = "application/json";
            WebResponse response = request.GetResponse();
            return response;
        }

>>>>>>> 38b502a27588535851d97ce9a40e1963534b992a
    }
}