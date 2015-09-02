using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WalkSploration.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        //Optional
        public string Email { get; set; }
        public Location StartLocation { get; set; }

        //Check  whether or not these need to be virtual
        public virtual List<PointOfInterest> RecentTrips { get; set; }
        public virtual List<PointOfInterest> FavoritesList { get; set; }
    }
}