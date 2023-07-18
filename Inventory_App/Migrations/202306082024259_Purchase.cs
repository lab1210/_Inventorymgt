namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Purchase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplierID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.SupplierID);
            
            CreateTable(
                "dbo.PurchaseProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        Selected = c.Boolean(nullable: false),
                        Purchase_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.Purchase_Id)
                .Index(t => t.ProductID)
                .Index(t => t.Purchase_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.PurchaseProducts", "Purchase_Id", "dbo.Purchases");
            DropForeignKey("dbo.PurchaseProducts", "ProductID", "dbo.Products");
            DropIndex("dbo.PurchaseProducts", new[] { "Purchase_Id" });
            DropIndex("dbo.PurchaseProducts", new[] { "ProductID" });
            DropIndex("dbo.Purchases", new[] { "SupplierID" });
            DropTable("dbo.PurchaseProducts");
            DropTable("dbo.Purchases");
        }
    }
}
