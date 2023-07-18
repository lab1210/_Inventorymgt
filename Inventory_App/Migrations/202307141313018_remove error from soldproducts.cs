namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeerrorfromsoldproducts : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SoldProducts", "ErrorMessage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SoldProducts", "ErrorMessage", c => c.String());
        }
    }
}
