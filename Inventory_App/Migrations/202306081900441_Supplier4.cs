namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Supplier4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "CountryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Suppliers", "CountryID");
            AddForeignKey("dbo.Suppliers", "CountryID", "dbo.Countries", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Suppliers", "CountryID", "dbo.Countries");
            DropIndex("dbo.Suppliers", new[] { "CountryID" });
            DropColumn("dbo.Suppliers", "CountryID");
        }
    }
}
