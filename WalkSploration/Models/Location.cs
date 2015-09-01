using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WalkSploration.Models
{
    public class Location
    {
        public decimal Latitude { get; }
        public decimal Longitude { get; }

        public Location (decimal lat, decimal lon)
        {
            this.Latitude = lat;
            this.Longitude = lon;
        }
    }

    
}