namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InventoryReport3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.InventoryReports", "SalesID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InventoryReports", "SalesID", c => c.Int(nullable: false));
        }
    }
}
