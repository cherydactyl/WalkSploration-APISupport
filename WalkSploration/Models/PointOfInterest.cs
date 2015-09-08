using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalkSploration.Models
{
    public class PointOfInterest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int PointOfInterestId { get; set; }                    // Point of Interest ID
        public Location location { get; set; }         //prefer to make location not malleable
        public string Name { get; set; }               // A short label
        public string Address { get; set; }            // Street address
        public string Category { get; set; }           // For future developments
        public string MapPinURL { get; set; }          // To store the URL for the map pin
        public string GooglePlaceId { get; set; }      // To store the unique google place id

        public PointOfInterest(decimal lat, decimal lng, string googID)
        {
            this.location = new Location(lat, lng);
            this.GooglePlaceId = googID;
        }

        public decimal getLatitude()
        {
            return this.location.latitude;
        }

        public decimal getLongitude()
        {
            return this.location.longitude;
        }
    }
}