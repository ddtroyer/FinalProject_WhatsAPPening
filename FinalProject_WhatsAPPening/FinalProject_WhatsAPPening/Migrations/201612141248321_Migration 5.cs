namespace FinalProject_WhatsAPPening.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ResultViewModels", "ActivityResult_Venue", "dbo.Activities");
            DropForeignKey("dbo.ResultViewModels", "RestaurantResult_Name", "dbo.Restaurants");
            DropIndex("dbo.ResultViewModels", new[] { "ActivityResult_Venue" });
            DropIndex("dbo.ResultViewModels", new[] { "RestaurantResult_Name" });
            RenameColumn(table: "dbo.ResultViewModels", name: "ActivityResult_Venue", newName: "ActivityResult_Id");
            RenameColumn(table: "dbo.ResultViewModels", name: "RestaurantResult_Name", newName: "RestaurantResult_Id");
            DropPrimaryKey("dbo.Activities");
            DropPrimaryKey("dbo.Restaurants");
            AddColumn("dbo.Restaurants", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ResultViewModels", "ActivityResult_Id", c => c.Int());
            AlterColumn("dbo.ResultViewModels", "RestaurantResult_Id", c => c.Int());
            AlterColumn("dbo.Activities", "Venue", c => c.String());
            AlterColumn("dbo.Restaurants", "Name", c => c.String());
            AddPrimaryKey("dbo.Activities", "Id");
            AddPrimaryKey("dbo.Restaurants", "Id");
            CreateIndex("dbo.ResultViewModels", "ActivityResult_Id");
            CreateIndex("dbo.ResultViewModels", "RestaurantResult_Id");
            AddForeignKey("dbo.ResultViewModels", "ActivityResult_Id", "dbo.Activities", "Id");
            AddForeignKey("dbo.ResultViewModels", "RestaurantResult_Id", "dbo.Restaurants", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResultViewModels", "RestaurantResult_Id", "dbo.Restaurants");
            DropForeignKey("dbo.ResultViewModels", "ActivityResult_Id", "dbo.Activities");
            DropIndex("dbo.ResultViewModels", new[] { "RestaurantResult_Id" });
            DropIndex("dbo.ResultViewModels", new[] { "ActivityResult_Id" });
            DropPrimaryKey("dbo.Restaurants");
            DropPrimaryKey("dbo.Activities");
            AlterColumn("dbo.Restaurants", "Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Activities", "Venue", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.ResultViewModels", "RestaurantResult_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.ResultViewModels", "ActivityResult_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Restaurants", "Id");
            AddPrimaryKey("dbo.Restaurants", "Name");
            AddPrimaryKey("dbo.Activities", "Venue");
            RenameColumn(table: "dbo.ResultViewModels", name: "RestaurantResult_Id", newName: "RestaurantResult_Name");
            RenameColumn(table: "dbo.ResultViewModels", name: "ActivityResult_Id", newName: "ActivityResult_Venue");
            CreateIndex("dbo.ResultViewModels", "RestaurantResult_Name");
            CreateIndex("dbo.ResultViewModels", "ActivityResult_Venue");
            AddForeignKey("dbo.ResultViewModels", "RestaurantResult_Name", "dbo.Restaurants", "Name");
            AddForeignKey("dbo.ResultViewModels", "ActivityResult_Venue", "dbo.Activities", "Venue");
        }
    }
}
