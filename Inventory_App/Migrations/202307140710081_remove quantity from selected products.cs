namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removequantityfromselectedproducts : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SelectedProducts", "quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SelectedProducts", "quantity", c => c.Int(nullable: false));
        }
    }
}
