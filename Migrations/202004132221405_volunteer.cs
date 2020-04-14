namespace HospitalProject_Team4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class volunteer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FAQs",
                c => new
                    {
                        FAQId = c.Int(nullable: false, identity: true),
                        question = c.String(),
                        answer = c.String(),
                    })
                .PrimaryKey(t => t.FAQId);
            
            AddColumn("dbo.AspNetUsers", "IsAdmin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsAdmin");
            DropTable("dbo.FAQs");
        }
    }
}
