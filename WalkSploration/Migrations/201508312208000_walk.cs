namespace WalkSploration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class walk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PointOfInterests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        Category = c.String(),
                        MapPinURL = c.String(),
                        User_UserID = c.Int(),
                        User_UserID1 = c.Int(),
                        User_UserID2 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .ForeignKey("dbo.Users", t => t.User_UserID1)
                .ForeignKey("dbo.Users", t => t.User_UserID2)
                .Index(t => t.User_UserID)
                .Index(t => t.User_UserID1)
                .Index(t => t.User_UserID2);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(),
                        StartLocation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.PointOfInterests", t => t.StartLocation_Id)
                .Index(t => t.StartLocation_Id);
            
            CreateTable(
                "dbo.UsersPointsOfInterest",
                c => new
                    {
                        UsersRefId = c.Int(nullable: false),
                        PointOfInterestsRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UsersRefId, t.PointOfInterestsRefId })
                .ForeignKey("dbo.Users", t => t.UsersRefId, cascadeDelete: true)
                .ForeignKey("dbo.PointOfInterests", t => t.PointOfInterestsRefId, cascadeDelete: true)
                .Index(t => t.UsersRefId)
                .Index(t => t.PointOfInterestsRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PointOfInterests", "User_UserID2", "dbo.Users");
            DropForeignKey("dbo.Users", "StartLocation_Id", "dbo.PointOfInterests");
            DropForeignKey("dbo.PointOfInterests", "User_UserID1", "dbo.Users");
            DropForeignKey("dbo.UsersPointsOfInterest", "PointOfInterestsRefId", "dbo.PointOfInterests");
            DropForeignKey("dbo.UsersPointsOfInterest", "UsersRefId", "dbo.Users");
            DropForeignKey("dbo.PointOfInterests", "User_UserID", "dbo.Users");
            DropIndex("dbo.UsersPointsOfInterest", new[] { "PointOfInterestsRefId" });
            DropIndex("dbo.UsersPointsOfInterest", new[] { "UsersRefId" });
            DropIndex("dbo.Users", new[] { "StartLocation_Id" });
            DropIndex("dbo.PointOfInterests", new[] { "User_UserID2" });
            DropIndex("dbo.PointOfInterests", new[] { "User_UserID1" });
            DropIndex("dbo.PointOfInterests", new[] { "User_UserID" });
            DropTable("dbo.UsersPointsOfInterest");
            DropTable("dbo.Users");
            DropTable("dbo.PointOfInterests");
        }
    }
}
