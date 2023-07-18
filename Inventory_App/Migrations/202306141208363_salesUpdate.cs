namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class salesUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SoldProducts", "ProductID", "dbo.Products");
            DropIndex("dbo.SoldProducts", new[] { "ProductID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.SoldProducts", "ProductID");
            AddForeignKey("dbo.SoldProducts", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
        }
    }
}
