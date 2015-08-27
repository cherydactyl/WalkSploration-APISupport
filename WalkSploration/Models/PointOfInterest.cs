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
<<<<<<< HEAD
       public int Id { get; set; }                    // Point of Interest ID
       public float Latitude { get; set; }            // lattitude of location
       public float Longitude { get; set; }           // longitude of location
       public string Name { get; set; }               // A short label
       public string Address { get; set; }            // Street address
       public string Category { get; set; }           // For future developments
       public string MapPinURL { get; set; }          // To store the URL for the map pin

        //Foreign Key
        public int UserID { get; set; }          // For possibly associating with a user
        //Navigation Property                    
        public User User { get; set; }           // For possibly associating with a user
=======
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
>>>>>>> e94b2b58cd564a29986348a68ca648856daea822
    }

    

}