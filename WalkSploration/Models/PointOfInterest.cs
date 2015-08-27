using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Device.Location;   /* more info here:  https://msdn.microsoft.com/en-us/library/system.device.location.geocoordinate(v=vs.110).aspx
//                                You may not be able to run this properly without adding the following NuGet Package in the 
//                                Package Manager Console command line: 'Install-Package System.Device.Location.Portable'   -  ak 8.24.15*/

namespace WalkSploration.Models
{
    public class PointOfInterest
    {
        string place_ID { get; set; }            // Google Places api unique id
        float lattitude { get; set; }            // lattitude of location
        float longitude { get; set; }            // longitude of location
        String name { get; set; }                // A short label
        String address { get; set; }             // Street address
        String category { get; set; }            // For future developments

        PointOfInterest(string G_place_ID, float lat, float lon)
        {
            place_ID = G_place_ID;
            lattitude = lat;
            longitude = lon;
        }
    }

    

}