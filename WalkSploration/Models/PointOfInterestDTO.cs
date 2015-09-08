using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WalkSploration.Models
{
    public class PointOfInterestDTO
    {
        public int Id { get; set; }
        public Location location { get; set; }
    }

    public class PointOfInterestDetailDTO
    {
        public int Id { get; set; }                    // Point of Interest ID
        public Location location { get; set; }         //prefer to make location not malleable
        public string Name { get; set; }               // A short label
        public string Address { get; set; }            // Street address
        public string Category { get; set; }           // For future developments
    }
}