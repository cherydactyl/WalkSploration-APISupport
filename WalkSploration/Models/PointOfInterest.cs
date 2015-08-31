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
        public int Id { get; set; }                    // Point of Interest ID
        public float Latitude { get; set; }            // lattitude of location
        public float Longitude { get; set; }           // longitude of location
        public string Name { get; set; }               // A short label
        public string Address { get; set; }            // Street address
        public string Category { get; set; }           // For future developments
        public string MapPinURL { get; set; }          // To store the URL for the map pin

        public string GooglePlaceId;                   // To store the unique google place id

        //Foreign Key
        public int UserID { get; set; }          // For possibly associating with a user
        //Navigation Property                    
        public User User { get; set; }           // For possibly associating with a user
    }
}