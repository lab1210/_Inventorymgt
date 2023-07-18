namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Productupdate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "InStockQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "PurchasedQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "SoldQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "PurchasedAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "SoldAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "SoldAmount");
            DropColumn("dbo.Products", "PurchasedAmount");
            DropColumn("dbo.Products", "SoldQuantity");
            DropColumn("dbo.Products", "PurchasedQuantity");
            DropColumn("dbo.Products", "InStockQuantity");
        }
    }
}
