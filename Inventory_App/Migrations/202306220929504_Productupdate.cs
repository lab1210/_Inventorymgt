namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Productupdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "InStockQuantity");
            DropColumn("dbo.Products", "PurchasedQuantity");
            DropColumn("dbo.Products", "SoldQuantity");
            DropColumn("dbo.Products", "PurchasedAmount");
            DropColumn("dbo.Products", "SoldAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "SoldAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "PurchasedAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "SoldQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "PurchasedQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "InStockQuantity", c => c.Int(nullable: false));
        }
    }
}
