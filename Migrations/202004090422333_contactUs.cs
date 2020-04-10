namespace HospitalProject_Team4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactUs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        message_id = c.Int(nullable: false, identity: true),
                        first_name = c.String(),
                        last_name = c.String(),
                        email = c.String(),
                        cell_phone = c.String(),
                        question = c.String(),
                        date = c.DateTime(nullable: false),
                        category_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.message_id);
            
            CreateTable(
                "dbo.MessageCategories",
                c => new
                    {
                        category_id = c.Int(nullable: false, identity: true),
                        category_name = c.String(),
                    })
                .PrimaryKey(t => t.category_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MessageCategories");
            DropTable("dbo.ContactUs");
        }
    }
}
