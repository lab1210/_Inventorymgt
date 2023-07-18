namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addstocktosoldproducts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SoldProducts", "stock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SoldProducts", "stock");
        }
    }
}
