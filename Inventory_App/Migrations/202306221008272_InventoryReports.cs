namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InventoryReports : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InventoryReports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        InStockQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InventoryReports", "ProductID", "dbo.Products");
            DropIndex("dbo.InventoryReports", new[] { "ProductID" });
            DropTable("dbo.InventoryReports");
        }
    }
}
