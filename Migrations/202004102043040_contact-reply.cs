namespace HospitalProject_Team4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactreply : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactUs", "reply", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactUs", "reply");
        }
    }
}
