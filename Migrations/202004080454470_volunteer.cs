namespace HospitalProject_Team4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class volunteer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VolunteerRecruitments",
                c => new
                    {
                        volunteer_id = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        HasFile = c.Int(nullable: false),
                        volunteer_FileExtension = c.String(),
                        volunteer_specialization = c.String(),
                        volunteer_status = c.String(),
                    })
                .PrimaryKey(t => t.volunteer_id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VolunteerRecruitments", "user_id", "dbo.AspNetUsers");
            DropIndex("dbo.VolunteerRecruitments", new[] { "user_id" });
            DropTable("dbo.VolunteerRecruitments");
        }
    }
}
