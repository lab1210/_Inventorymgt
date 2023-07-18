namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addquantity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SelectedProducts", "quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SelectedProducts", "quantity");
        }
    }
}
