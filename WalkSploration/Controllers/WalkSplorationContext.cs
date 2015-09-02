using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WalkSploration.Models
{
    public class WalkSplorationContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public WalkSplorationContext() : base("WalkSplorationContext")
        {
        }

        public System.Data.Entity.DbSet<WalkSploration.Models.PointOfInterest> PointOfInterests { get; set; }

        public System.Data.Entity.DbSet<WalkSploration.Models.User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                        .HasMany<PointOfInterest>(s => s.PointOfOntersts)
                        .WithMany(c => c.users)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("UsersRefId");
                            cs.MapRightKey("PointOfInterestsRefId");
                            cs.ToTable("UsersPointsOfInterest");
                        });
        }
    
    }
}
