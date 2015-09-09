using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WalkSploration.Models
{
    public class Location
    {
        public decimal latitude { get; set; }
        public decimal longitude { get; set; }

        public Location(decimal lat, decimal lon)
        {
            this.latitude = lat;
            this.longitude = lon;
        }
    }
}