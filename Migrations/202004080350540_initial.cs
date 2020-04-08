namespace HospitalProject_Team4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        user_id = c.Int(nullable: false, identity: true),
                        first_name = c.String(),
                        last_name = c.String(),
                        address = c.String(),
                        home_phone = c.String(),
                        cell_phone = c.String(),
                        dob = c.String(),
                        gender = c.String(),
                        username = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.user_id);
            
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        DonationID = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        donor_mail = c.String(),
                        donation_amount = c.Int(nullable: false),
                        donated_on = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DonationID)
                .ForeignKey("dbo.AspNetUsers", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donations", "user_id", "dbo.AspNetUsers");
            DropIndex("dbo.Donations", new[] { "user_id" });
            DropTable("dbo.Donations");
            DropTable("dbo.AspNetUsers");
        }
    }
}
