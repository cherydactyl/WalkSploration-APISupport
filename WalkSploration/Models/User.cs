using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WalkSploration.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }

        //Optional
        public Location StartLocation { get; set; }

        //Check  whether or not these need to be virtual
        public virtual ICollection<PointOfInterest> RecentTrips { get; set; }
        public virtual ICollection<PointOfInterest> FavoritesList { get; set; }
    }
}