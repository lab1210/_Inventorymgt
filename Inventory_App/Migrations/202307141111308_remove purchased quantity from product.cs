namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removepurchasedquantityfromproduct : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "PurchasedQuantity");
            DropColumn("dbo.Products", "PurchasedAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "PurchasedAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Products", "PurchasedQuantity", c => c.Int(nullable: false));
        }
    }
}
