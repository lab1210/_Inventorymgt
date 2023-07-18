namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addcreatedby : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brands", "CreatedBy", c => c.String());
            AddColumn("dbo.Categories", "CreatedBy", c => c.String());
            AddColumn("dbo.Cities", "CreatedBy", c => c.String());
            AddColumn("dbo.Countries", "CreatedBy", c => c.String());
            AddColumn("dbo.Customers", "CreatedBy", c => c.String());
            AddColumn("dbo.Expenses", "CreatedBy", c => c.String());
            AddColumn("dbo.Products", "CreatedBy", c => c.String());
            AddColumn("dbo.Units", "CreatedBy", c => c.String());
            AddColumn("dbo.Purchases", "CreatedBy", c => c.String());
            AddColumn("dbo.Suppliers", "CreatedBy", c => c.String());
            AddColumn("dbo.Sales", "CreatedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "CreatedBy");
            DropColumn("dbo.Suppliers", "CreatedBy");
            DropColumn("dbo.Purchases", "CreatedBy");
            DropColumn("dbo.Units", "CreatedBy");
            DropColumn("dbo.Products", "CreatedBy");
            DropColumn("dbo.Expenses", "CreatedBy");
            DropColumn("dbo.Customers", "CreatedBy");
            DropColumn("dbo.Countries", "CreatedBy");
            DropColumn("dbo.Cities", "CreatedBy");
            DropColumn("dbo.Categories", "CreatedBy");
            DropColumn("dbo.Brands", "CreatedBy");
        }
    }
}
