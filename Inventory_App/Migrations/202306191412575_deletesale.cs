namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletesale : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sales", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Sales", "ProductID", "dbo.Products");
            DropForeignKey("dbo.SoldProducts", "Sale_Id", "dbo.Sales");
            DropForeignKey("dbo.SalesReports", "SaleID", "dbo.Sales");
            DropIndex("dbo.Sales", new[] { "CustomerID" });
            DropIndex("dbo.Sales", new[] { "ProductID" });
            DropIndex("dbo.SoldProducts", new[] { "Sale_Id" });
            DropIndex("dbo.SalesReports", new[] { "SaleID" });
            DropTable("dbo.Sales");
            DropTable("dbo.SoldProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SoldProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        Selected = c.Boolean(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sale_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.SalesReports", "SaleID");
            CreateIndex("dbo.SoldProducts", "Sale_Id");
            CreateIndex("dbo.Sales", "ProductID");
            CreateIndex("dbo.Sales", "CustomerID");
            AddForeignKey("dbo.SalesReports", "SaleID", "dbo.Sales", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SoldProducts", "Sale_Id", "dbo.Sales", "Id");
            AddForeignKey("dbo.Sales", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Sales", "CustomerID", "dbo.Customers", "id", cascadeDelete: true);
        }
    }
}
