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
using System.Text;
namespace WalkSploration.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Start()
        {
            return View();
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Walk(FormCollection collection)
        {
            Location start = new Location(decimal.Parse(collection["startLatitude"]), decimal.Parse(collection["startLongitude"]));
            int time = int.Parse(collection["timeInput"]);
            
            List<PointOfInterest> radarList = getPlaces(start, time);
            List<PointOfInterest> goldilocks = screenPlaces(radarList, start, time);
            PointOfInterest chosen = null;

                if (goldilocks.Count() > 0)
                {
                    chosen = goldilocks[0];
                }
                else if (radarList.Count() > 0)
                {
                    chosen = radarList[radarList.Count() - 1];
                }

                if (chosen != null)
                {
                    ViewBag.GoogleId = chosen.GooglePlaceId;
                    ViewBag.Latitude = chosen.location.latitude;
                    ViewBag.Longitude = chosen.location.longitude;

                    ViewBag.OriginLat = start.latitude;
                    ViewBag.OriginLon = start.longitude;

                    ViewBag.NoneInRange = false;
                }
                else
                {
                    ViewBag.NoneInRange = true;
                }

                ViewBag.time = time;

             

            if (chosen != null){
                ViewBag.GoogleId = chosen.GooglePlaceId;
                ViewBag.Latitude = chosen.location.latitude;
                ViewBag.Longitude = chosen.location.longitude;
                ViewBag.NoneInRange = false;
            }
            else
            {
                ViewBag.NoneInRange = true;
            }
            ViewBag.time = time;

            string poiURL = "http://maps.google.com/maps?q=";
            poiURL += chosen.location.latitude + "," + chosen.location.longitude;
            ViewBag.PoIMapLink = poiURL; 

            return View();
        }

        // !!!!  HELPER FUNCTIONS  !!!!

        public List<PointOfInterest> getPlaces(Location start, int timeInMinutes)
        {
            //create query
            //build ("https://maps.googleapis.com/maps/api/place/nearbysearch/output?" + parameters)
            //OR (less data) 
            string URI = "https://maps.googleapis.com/maps/api/place/radarsearch/json?";
            //add parameters
            //key
            URI += "key=" + (new Secrets()).GoogleAPIServerKey + "&";
            //location
            URI += "location=" + start.latitude.ToString() + "," + start.longitude.ToString() + "&";
            //radius; estimate 1 meter per second walking speed
            URI += "radius=" + (timeInMinutes * 60 / 2).ToString() + "&";
            //types; start with "park" and possibly add more later
            //see https://developers.google.com/places/supported_types for list of types
            URI += "types=park";
            //create a new, empty list of Points Of Interest
            List<PointOfInterest> candidatePoIs = new List<PointOfInterest>();
            //request processing
            var googleRadarObject = JToken.Parse(callAPIgetJSon(URI));
            var status = googleRadarObject.Children<JProperty>().FirstOrDefault(x => x.Name == "status").Value;
            if (status.ToString() == "OK")
            {
                var resultsArray = googleRadarObject.Children<JProperty>().FirstOrDefault(x => x.Name == "results").Value;
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
            //create distance matrix query
            string URI = "https://maps.googleapis.com/maps/api/distancematrix/json?";

            //add parameters
            //key
            URI += "key=" + (new Secrets()).GoogleAPIServerKey + "&";
            //specifiy walking
            URI += "mode=walking&";
            //origin location
            URI += "origins=" + start.latitude.ToString() + "," + start.longitude.ToString() + "&";
            //list all candidate points of interest by lat/lon as destinations
            URI += "destinations=";
            //iterate over candidate destinations, and add each location, separated by a pipe |
            int count = candidates.Count();
            for (int i = 0; i < count; i++)
            {
                URI += candidates[i].getLatitude().ToString() + "," + candidates[i].getLongitude().ToString();
                if (i < count - 1)  // if not the last item in the list
                {
                    URI += "|";     //add a pipe to separate destinations
                }
            }

            List<PointOfInterest> viable = new List<PointOfInterest>();      //create a new empty list
            //calculate Goldilocks range (not too far but also not too close) in seconds
            //use 90-100% of available one-way time to start
            //may need to iterate or otherwise process & if so, should probably save the times instead of make decisions in loop
            //note that these use integer math
            int ceiling = (timeInMinutes * 60) / 2;   //max length of each leg of round trip
            int floor = (ceiling * 9) / 10;           //min length of each leg of round trip

            var client = new WebClient();
            var values = System.Web.HttpUtility.ParseQueryString(string.Empty);
            var result = client.DownloadData(URI.ToString());
            var json = Encoding.UTF8.GetString(result);
            var serializer = new JavaScriptSerializer();
            var distanceResponse = serializer.Deserialize<DistanceResponse>(json);
            //extract elements' travel times
            //remember there is only one destination, so the elements list the times to destinations in order
            if (string.Equals("OK", distanceResponse.Status, StringComparison.OrdinalIgnoreCase))
            {
                var elements = (distanceResponse.Rows[0]).Elements;

                for (int i = 0; i < count; i++)
                {
                    //extract the time in seconds from origin to the current (i'th) destination
                    if (string.Equals("OK", distanceResponse.Status, StringComparison.OrdinalIgnoreCase))
                    {
                        // making a new int value to be able to better understand what the actual value is.
                        int value = elements[i].Duration.Value;
                        //compare to Goldilocks zone to evaluate and add to list if in the range
                        if (value > floor && value <= ceiling)
                        {
                            viable.Add(candidates[i]);
                        }
                    }
                }
            }
            Console.WriteLine(candidates);
            return viable;
        }
        string callAPIgetJSon(string URI)
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