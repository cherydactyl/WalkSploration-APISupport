using WalkSploration.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WalkSploration.DAL    
{
    public class PoiContext:DbContext
    {
        public PoiContext() : base("PoiContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PointOfInterest> POIs { get; set; }

    }
}