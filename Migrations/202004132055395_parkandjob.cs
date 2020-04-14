namespace HospitalProject_Team4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parkandjob : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        ApplicationID = c.Int(nullable: false, identity: true),
                        Resume = c.Boolean(nullable: false),
                        FormerEmployer = c.String(),
                        Reference1_Name = c.String(),
                        Reference1_Email = c.String(),
                        Reference2_Name = c.String(),
                        Reference2_Email = c.String(),
                        Reference3_Name = c.String(),
                        Reference3_Email = c.String(),
                    })
                .PrimaryKey(t => t.ApplicationID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.FAQs",
                c => new
                    {
                        FAQId = c.Int(nullable: false, identity: true),
                        question = c.String(),
                        answer = c.String(),
                    })
                .PrimaryKey(t => t.FAQId);
            
            CreateTable(
                "dbo.JobPostings",
                c => new
                    {
                        PostingID = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        JobDescription = c.String(),
                        Accepter = c.String(),
                        ApplicationDeadline = c.DateTime(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostingID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.ParkingSpots",
                c => new
                    {
                        SpotID = c.Int(nullable: false, identity: true),
                        lot = c.String(),
                        location = c.String(),
                        branch = c.String(),
                    })
                .PrimaryKey(t => t.SpotID);
            
            CreateTable(
                "dbo.SpotBookings",
                c => new
                    {
                        SpotBookingID = c.Int(nullable: false, identity: true),
                        BookingDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        SpotID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SpotBookingID)
                .ForeignKey("dbo.ParkingSpots", t => t.SpotID, cascadeDelete: true)
                .Index(t => t.SpotID);
            
            AddColumn("dbo.AspNetUsers", "IsAdmin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpotBookings", "SpotID", "dbo.ParkingSpots");
            DropForeignKey("dbo.JobPostings", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.SpotBookings", new[] { "SpotID" });
            DropIndex("dbo.JobPostings", new[] { "DepartmentID" });
            DropColumn("dbo.AspNetUsers", "IsAdmin");
            DropTable("dbo.SpotBookings");
            DropTable("dbo.ParkingSpots");
            DropTable("dbo.JobPostings");
            DropTable("dbo.FAQs");
            DropTable("dbo.Departments");
            DropTable("dbo.Applications");
        }
    }
}
