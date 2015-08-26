using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WalkSploration.Models
{
    public class User
    {
        public int UserID { get; set; }
        [Required]
        public string Name { get; set; }

        //Optional
        public string Email { get; set; }
        public PointOfInterest StartLocation { get; set; }
        public List<PointOfInterest> RecentTrips { get; set; }
        public List<PointOfInterest> FavoritesList { get; set; }
    }
}