namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewSalesModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sales",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CustomerID = c.Int(nullable: false),
                    Date = c.DateTime(nullable: false),
                    Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    ProductID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.SoldProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sale_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sales", t => t.Sale_Id)
                .Index(t => t.Sale_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SoldProducts", "Sale_Id", "dbo.Sales");
            DropForeignKey("dbo.Sales", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Sales", "CustomerID", "dbo.Customers");
            DropIndex("dbo.SoldProducts", new[] { "Sale_Id" });
            DropIndex("dbo.Sales", new[] { "ProductID" });
            DropIndex("dbo.Sales", new[] { "CustomerID" });
            DropTable("dbo.SoldProducts");
            DropTable("dbo.Sales");
        }
    }
}
