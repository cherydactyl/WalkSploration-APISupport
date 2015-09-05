using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WalkSploration.Models.PlacesRadarResponse
{
    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Geometry
    {
        public Location location { get; set; }
    }

    public class Result
    {
        public Geometry geometry { get; set; }
        public string id { get; set; }
        public string place_id { get; set; }
        public string reference { get; set; }
    }

    public class RootObject
    {
        public List<object> html_attributions { get; set; }
        public List<Result> results { get; set; }
        public string status { get; set; }
    }
}