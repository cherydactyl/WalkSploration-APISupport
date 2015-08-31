using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace WalkSploration.Models
{
    public class DistanceMatrix
    {
        public string Status { get; set; }
        public string OriginAddress { get; set; }
        public int TravelTime { get; set; }
    }
}