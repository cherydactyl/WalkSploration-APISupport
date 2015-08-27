using Google.GData.Client;          //Install-Package Google.GData.Client, Install-Package Newtonsoft.Json
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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


        //helper functions here
        public List<PointOfInterest> getPlaces(long latitude, long longitude)
        {
            //create query
            //build ("https://maps.googleapis.com/maps/api/place/nearbysearch/output?" + parameters)
            //OR (less data) 
            string URI = "https://maps.googleapis.com/maps/api/place/radarsearch/output?";
            //add parameters
            //key
            //query += "?key = <server key>         //not needed until app passes dev quota
            //location
            URI += "location=" + latitude.ToString() + "," + longitude.ToString() + "&";
            //radius; 2 miles ~= 3200 meters; google requires radiun in meters, max 50,000
            URI += "radius=3200&";
            //types; start with "park" and possibly add more later
            //see https://developers.google.com/places/supported_types for list of types
            URI += "types=park";
            
            //request processing
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
            request.Method = "POST";
            request.ContentType = "application/json";
            

            //create a new list
            List<PointOfInterest> PoIs = new List<PointOfInterest>();

            //iterate over the json and parse into PointsOfInterest, placing each in list

            //return processed list
            return PoIs;
        }

    }
}