namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Supplier5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "CityID", c => c.Int(nullable: false));
            CreateIndex("dbo.Suppliers", "CityID");
            AddForeignKey("dbo.Suppliers", "CityID", "dbo.Cities", "ID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Suppliers", "CityID", "dbo.Cities");
            DropIndex("dbo.Suppliers", new[] { "CityID" });
            DropColumn("dbo.Suppliers", "CityID");
        }
    }
}
