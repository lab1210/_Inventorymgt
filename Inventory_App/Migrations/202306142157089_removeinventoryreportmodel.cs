namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeinventoryreportmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InventoryReports", "ProductID", "dbo.Products");
            DropForeignKey("dbo.InventoryReports", "PurchaseID", "dbo.Purchases");
            DropForeignKey("dbo.InventoryReports", "SaleID", "dbo.Sales");
            DropIndex("dbo.InventoryReports", new[] { "ProductID" });
            DropIndex("dbo.InventoryReports", new[] { "PurchaseID" });
            DropIndex("dbo.InventoryReports", new[] { "SaleID" });
            DropTable("dbo.InventoryReports");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.InventoryReports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        InstockQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseID = c.Int(nullable: false),
                        SaleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.InventoryReports", "SaleID");
            CreateIndex("dbo.InventoryReports", "PurchaseID");
            CreateIndex("dbo.InventoryReports", "ProductID");
            AddForeignKey("dbo.InventoryReports", "SaleID", "dbo.Sales", "Id", cascadeDelete: true);
            AddForeignKey("dbo.InventoryReports", "PurchaseID", "dbo.Purchases", "Id", cascadeDelete: true);
            AddForeignKey("dbo.InventoryReports", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
        }
    }
}
