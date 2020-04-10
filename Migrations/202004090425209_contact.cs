namespace HospitalProject_Team4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contact : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ContactUs", "category_id");
            AddForeignKey("dbo.ContactUs", "category_id", "dbo.MessageCategories", "category_id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactUs", "category_id", "dbo.MessageCategories");
            DropIndex("dbo.ContactUs", new[] { "category_id" });
        }
    }
}
