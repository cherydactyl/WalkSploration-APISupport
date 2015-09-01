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
            //Grand Circus 42.3347, -83.0497; this is just a placeholder until actual start location set
            Location start = new Location((decimal)42.3347, (decimal)-83.0497);
            //int time = 15;  //sample time

            //screenPlaces(getPlaces((decimal)42.3347, (decimal)-83.0497), start, time);          
            return View();

        }

        //helper functions here
        public List<PointOfInterest> getPlaces(decimal latitude, decimal longitude, int timeInMinutes)
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
            //radius; estimate 1 meter per second walking speed
            URI += "radius="+ (timeInMinutes * 60 /2).ToString() +"&";
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
                    
                    //extract the google place id
                    string GooglePlaceId = item.Children<JProperty>().FirstOrDefault(x => x.Name == "place_id").Value.ToString();
                    //extract the lattitude from JSon structuret
                    decimal lat = decimal.Parse(
                        item.Children<JProperty>().FirstOrDefault(x => x.Name == "geometry").Value.
                        Children<JProperty>().FirstOrDefault(x => x.Name == "location").Value.
                        Children<JProperty>().FirstOrDefault(x => x.Name == "lat").Value.ToString());
                    //extract the longitude from JSon structure
                    decimal lng = decimal.Parse(
                        item.Children<JProperty>().FirstOrDefault(x => x.Name == "geometry").Value.
                        Children<JProperty>().FirstOrDefault(x => x.Name == "location").Value.
                        Children<JProperty>().FirstOrDefault(x => x.Name == "lng").Value.ToString());
                    //create new PoI with above properties
                    PointOfInterest point = new PointOfInterest(lat, lng, GooglePlaceId);
                    
                    //add it to the list of candidates
                    candidatePoIs.Add(point);
                }
            }
            //return processed list
            return candidatePoIs;
        }

        List<PointOfInterest> screenPlaces(List<PointOfInterest> candidates, Location start, int timeInMinutes)
        {
            //if the candidates list is empty, return the/an empty list
            if (!(candidates.Any<PointOfInterest>()))
                {
                return candidates;
            }

            //calculate Goldilocks range (not too far but also not too close) in seconds
            //use 90-100% of available one-way time to start; may need to iterate 
            //note that these 
            int ceiling = (timeInMinutes * 60)/2;   //max length of each leg of round trip
            int floor = (ceiling * 10) / 9;         //min desired length of each leg of round trip

            //form API call for distance matrix

            //call the API and get JSon string back

            //extract travel times

            //create a new empty list
            List<PointOfInterest> viable = new List<PointOfInterest>();

            //step through 


            return viable;
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