namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removePurchaseReport : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseReports", "ProductID", "dbo.Products");
            DropForeignKey("dbo.PurchaseReports", "PurchaseID", "dbo.Purchases");
            DropIndex("dbo.PurchaseReports", new[] { "ProductID" });
            DropIndex("dbo.PurchaseReports", new[] { "PurchaseID" });
            DropTable("dbo.PurchaseReports");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PurchaseReports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        PurchaseAmount = c.Int(nullable: false),
                        PurchaseQuantity = c.Int(nullable: false),
                        PurchaseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.PurchaseReports", "PurchaseID");
            CreateIndex("dbo.PurchaseReports", "ProductID");
            AddForeignKey("dbo.PurchaseReports", "PurchaseID", "dbo.Purchases", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PurchaseReports", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
        }
    }
}
