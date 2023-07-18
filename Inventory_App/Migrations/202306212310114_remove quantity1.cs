namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removequantity1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SelectedProducts", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SelectedProducts", "Quantity", c => c.Int(nullable: false));
        }
    }
}
