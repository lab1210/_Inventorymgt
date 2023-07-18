namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Purchase1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseProducts", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseProducts", "Price");
        }
    }
}
