using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Device.Location;   /* more info here:  https://msdn.microsoft.com/en-us/library/system.device.location.geocoordinate(v=vs.110).aspx
                                You may not be able to run this properly without adding the following NuGet Package in the 
                                Package Manager Console command line: 'Install-Package System.Device.Location.Portable'   -  ak 8.24.15*/

namespace WalkSploration.Models
{
    public class PointOfInterest
    {
        int place_ID;               // Point of Interest ID
        GeoCoordinate location;     // 
        String name;                // A short label
        String address;             // Street address
        String category;            // For future developments
    }
}