namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesale : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sales", "ProductID", "dbo.Products");
            DropIndex("dbo.Sales", new[] { "ProductID" });
            DropColumn("dbo.Sales", "ProductID");
            DropColumn("dbo.Sales", "quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Sales", "ProductID", c => c.Int(nullable: false));
            CreateIndex("dbo.Sales", "ProductID");
            AddForeignKey("dbo.Sales", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
        }
    }
}
