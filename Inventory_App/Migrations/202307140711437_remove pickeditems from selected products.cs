namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removepickeditemsfromselectedproducts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sales", "PickedItems_ID", "dbo.SelectedProducts");
            DropIndex("dbo.Sales", new[] { "PickedItems_ID" });
            DropColumn("dbo.Sales", "PickedItems_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "PickedItems_ID", c => c.Int());
            CreateIndex("dbo.Sales", "PickedItems_ID");
            AddForeignKey("dbo.Sales", "PickedItems_ID", "dbo.SelectedProducts", "ID");
        }
    }
}
