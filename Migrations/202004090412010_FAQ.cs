namespace HospitalProject_Team4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FAQ : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FAQs",
                c => new
                    {
                        FAQId = c.String(nullable: false, maxLength: 128),
                        question = c.String(),
                        answer = c.String(),
                    })
                .PrimaryKey(t => t.FAQId)
                .ForeignKey("dbo.AspNetUsers", t => t.FAQId)
                .Index(t => t.FAQId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FAQs", "FAQId", "dbo.AspNetUsers");
            DropIndex("dbo.FAQs", new[] { "FAQId" });
            DropTable("dbo.FAQs");
        }
    }
}
