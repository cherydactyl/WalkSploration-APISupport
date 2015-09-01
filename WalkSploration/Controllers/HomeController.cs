using System;
using Google.GData.Client;          //Install-Package Google.GData.Client, Install-Package Newtonsoft.Json
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
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace WalkSploration.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Grand Circus 42.3347, -83.0497

            Location start = new Location((decimal)42.3347, (decimal)-83.0497);

            //screenPlaces(getPlaces((decimal)42.3347, (decimal)-83.0497));          
            return View();

        }

        //helper functions here
        public List<PointOfInterest> getPlaces(decimal latitude, decimal longitude)
        {
            //create query
            //build ("https://maps.googleapis.com/maps/api/place/nearbysearch/output?" + parameters)
            //OR (less data) 
            string URI = "https://maps.googleapis.com/maps/api/place/radarsearch/json?";
            //add parameters
            //key
            URI += "key=" + (new Secrets()).GoogleAPIServerKey + "&";
            //location
            URI += "location=" + latitude.ToString() + "," + longitude.ToString() + "&";
            //radius; 2 miles ~= 3200 meters; google requires radius in meters, max 50,000
            URI += "radius=3200&";
            //types; start with "park" and possibly add more later
            //see https://developers.google.com/places/supported_types for list of types
            URI += "types=park";
           
            //create a new, empty list of Points Of Interest
            List<PointOfInterest> candidatePoIs = new List<PointOfInterest>();

            //request processing
            var googleRadarObject = JToken.Parse(callAPIgetJSon(URI));
            var status = googleRadarObject.Children<JProperty>().FirstOrDefault(x => x.Name == "status").Value;

            var resultsArray = googleRadarObject.Children<JProperty>().FirstOrDefault(x => x.Name == "results").Value;

            if (status.ToString() == "OK")
            {
                //iterate over the json and parse into PointsOfInterest, placing each in the list
                foreach (var item in resultsArray)
                {
                    PointOfInterest point = new PointOfInterest();
                    //extract and set the google place id in point
                    point.GooglePlaceId = item.Children<JProperty>().FirstOrDefault(x => x.Name == "place_id").Value.ToString();
                    //extract the lattitude from JSon structure and set in point
                    point.Latitude = decimal.Parse(
                        item.Children<JProperty>().FirstOrDefault(x => x.Name == "geometry").Value.
                        Children<JProperty>().FirstOrDefault(x => x.Name == "location").Value.
                        Children<JProperty>().FirstOrDefault(x => x.Name == "lat").Value.ToString());
                    //extract the longitude from JSon structure and set in point
                    point.Longitude = decimal.Parse(
                        item.Children<JProperty>().FirstOrDefault(x => x.Name == "geometry").Value.
                        Children<JProperty>().FirstOrDefault(x => x.Name == "location").Value.
                        Children<JProperty>().FirstOrDefault(x => x.Name == "lng").Value.ToString());
                    
                    candidatePoIs.Add(point);

                    Debug.WriteLine(point.GooglePlaceId.ToString());
                }
            }

            //return processed list
            return candidatePoIs;
        }

        string callAPIgetJSon (string URI)
        {
            //call API
            WebRequest request = WebRequest.Create(URI);
            request.Method = "GET";
            request.ContentType = "application/json";
            WebResponse response = request.GetResponse();

            //convert response to JSon string
            string jsonString;
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                jsonString = streamReader.ReadToEnd();
            }
            return jsonString;
        }
    }
}