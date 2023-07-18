namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSales : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SelectedProducts", newName: "SoldProducts");
            AddColumn("dbo.SoldProducts", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SoldProducts", "Quantity");
            RenameTable(name: "dbo.SoldProducts", newName: "SelectedProducts");
        }
    }
}
