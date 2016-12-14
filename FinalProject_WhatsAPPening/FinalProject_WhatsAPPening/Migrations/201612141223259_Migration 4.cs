namespace FinalProject_WhatsAPPening.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurants", "ZipCode", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "ZipCode", c => c.Int(nullable: false));
        }
    }
}
