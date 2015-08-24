using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WalkSploration.Models
{
    public class Location
    {
        //
        public double Lat { get; private set; }
        public double Lng { get; private set; }

        public Location (double lat, double lng)
        {
            this.Lat = lat;
            this.Lng = lng;
        }

        public override string ToString()
        {
            return String.Format("{0},{1}", this.Lat, this.Lng);
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Location latlng = obj as Location;
            if ((Object)latlng == null)
                return false;

            return (this.Lat == latlng.Lat) && (this.Lng == latlng.Lng);
        }

        public bool Equals(Location latlng)
        {
            if ((object)latlng == null)
                return false;

            return (this.Lat == latlng.Lat) && (this.Lng == latlng.Lng);
        }


        public override int GetHashCode()
        {
            return (int)Math.Sqrt(Math.Pow(this.Lat, 2) * Math.Pow(this.Lng, 2));
        }
    }
}