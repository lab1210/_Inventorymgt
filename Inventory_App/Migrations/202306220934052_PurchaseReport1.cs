namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseReport1 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.PurchaseID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.PurchaseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseReports", "PurchaseID", "dbo.Purchases");
            DropForeignKey("dbo.PurchaseReports", "ProductID", "dbo.Products");
            DropIndex("dbo.PurchaseReports", new[] { "PurchaseID" });
            DropIndex("dbo.PurchaseReports", new[] { "ProductID" });
            DropTable("dbo.PurchaseReports");
        }
    }
}
