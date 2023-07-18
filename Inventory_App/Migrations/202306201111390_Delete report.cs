namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deletereport : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseReports", "PurchaseID", "dbo.Purchases");
            DropForeignKey("dbo.SalesReports", "ProductID", "dbo.Products");
            DropIndex("dbo.PurchaseReports", new[] { "PurchaseID" });
            DropIndex("dbo.SalesReports", new[] { "ProductID" });
            DropTable("dbo.PurchaseReports");
            DropTable("dbo.SalesReports");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SalesReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        SaleID = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseReports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PurchaseID = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.SalesReports", "ProductID");
            CreateIndex("dbo.PurchaseReports", "PurchaseID");
            AddForeignKey("dbo.SalesReports", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
            AddForeignKey("dbo.PurchaseReports", "PurchaseID", "dbo.Purchases", "Id", cascadeDelete: true);
        }
    }
}
