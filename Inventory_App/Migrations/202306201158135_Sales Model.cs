namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalesModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sales", "ProductID", "dbo.Products");
            DropForeignKey("dbo.SoldProducts", "ProductID", "dbo.Products");
            DropIndex("dbo.Sales", new[] { "ProductID" });
            DropIndex("dbo.SoldProducts", new[] { "ProductID" });
            DropColumn("dbo.Sales", "ProductID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "ProductID", c => c.Int(nullable: false));
            CreateIndex("dbo.SoldProducts", "ProductID");
            CreateIndex("dbo.Sales", "ProductID");
            AddForeignKey("dbo.SoldProducts", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Sales", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
        }
    }
}
