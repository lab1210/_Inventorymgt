namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InventoryReport1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InventoryReports", "PurchaseID", c => c.Int(nullable: false));
            AddColumn("dbo.InventoryReports", "SalesID", c => c.Int(nullable: false));
            AddColumn("dbo.InventoryReports", "Sale_Id", c => c.Int());
            CreateIndex("dbo.InventoryReports", "PurchaseID");
            CreateIndex("dbo.InventoryReports", "Sale_Id");
            AddForeignKey("dbo.InventoryReports", "PurchaseID", "dbo.Purchases", "Id", cascadeDelete: true);
            AddForeignKey("dbo.InventoryReports", "Sale_Id", "dbo.Sales", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InventoryReports", "Sale_Id", "dbo.Sales");
            DropForeignKey("dbo.InventoryReports", "PurchaseID", "dbo.Purchases");
            DropIndex("dbo.InventoryReports", new[] { "Sale_Id" });
            DropIndex("dbo.InventoryReports", new[] { "PurchaseID" });
            DropColumn("dbo.InventoryReports", "Sale_Id");
            DropColumn("dbo.InventoryReports", "SalesID");
            DropColumn("dbo.InventoryReports", "PurchaseID");
        }
    }
}
