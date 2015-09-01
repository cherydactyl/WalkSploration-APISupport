using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WalkSploration.Models
{
    public class Location
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public Location (decimal lat, decimal lon)
        {
            this.Latitude = lat;
            this.Longitude = lon;
        }
    }

    
}