namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaleReport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalesReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Sale_id = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Sale_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.Sale_Id)
                .Index(t => t.ProductID)
                .Index(t => t.Sale_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesReports", "Sale_Id", "dbo.Sales");
            DropForeignKey("dbo.SalesReports", "ProductID", "dbo.Products");
            DropIndex("dbo.SalesReports", new[] { "Sale_Id" });
            DropIndex("dbo.SalesReports", new[] { "ProductID" });
            DropTable("dbo.SalesReports");
        }
    }
}
