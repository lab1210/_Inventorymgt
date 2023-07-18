namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseReport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseReports",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PurchaseID = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Purchases", t => t.PurchaseID, cascadeDelete: true)
                .Index(t => t.PurchaseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseReports", "PurchaseID", "dbo.Purchases");
            DropIndex("dbo.PurchaseReports", new[] { "PurchaseID" });
            DropTable("dbo.PurchaseReports");
        }
    }
}
