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
        int pointOfInterest_ID { get; set; }               // Point of Interest ID
        float latitude { get; set; }            // lattitude of location
        float longitude { get; set; }            // longitude of location
        String name { get; set; }                // A short label
        String address { get; set; }             // Street address
        String category { get; set; }            // For future developments
        String mapPinURL { get; set; }           // To store the URL for the map pin

        //Foreign Key
        public int UserID { get; set; }          // For possibly associating with a user
        //Navigation Property                    
        public User User { get; set; }           // For possibly associating with a user
    }
}