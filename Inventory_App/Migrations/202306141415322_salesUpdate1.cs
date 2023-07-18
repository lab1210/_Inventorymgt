namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class salesUpdate1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.SoldProducts", "ProductID");
            AddForeignKey("dbo.SoldProducts", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SoldProducts", "ProductID", "dbo.Products");
            DropIndex("dbo.SoldProducts", new[] { "ProductID" });
        }
    }
}
