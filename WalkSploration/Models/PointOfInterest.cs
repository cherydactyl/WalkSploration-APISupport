using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Device.Location;

namespace WalkSploration.Models
{
    public class PointOfInterest
    {
        int _ID;
        GeoCoordinate location;
        String name;                //a short label
        String address;             //street address
        String category;            //for future developments
    }
}