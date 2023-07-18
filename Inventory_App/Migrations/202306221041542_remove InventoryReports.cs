namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeInventoryReports : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InventoryReports", "ProductID", "dbo.Products");
            DropIndex("dbo.InventoryReports", new[] { "ProductID" });
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
                        InStockQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.InventoryReports", "ProductID");
            AddForeignKey("dbo.InventoryReports", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
        }
    }
}
