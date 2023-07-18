namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saleupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "PickedItems_ID", c => c.Int());
            CreateIndex("dbo.Sales", "PickedItems_ID");
            AddForeignKey("dbo.Sales", "PickedItems_ID", "dbo.SelectedProducts", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "PickedItems_ID", "dbo.SelectedProducts");
            DropIndex("dbo.Sales", new[] { "PickedItems_ID" });
            DropColumn("dbo.Sales", "PickedItems_ID");
        }
    }
}
