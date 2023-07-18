namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeamountinexpensefrominttodecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Expenses", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Expenses", "Amount", c => c.Int(nullable: false));
        }
    }
}
