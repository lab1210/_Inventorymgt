namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatesoldproducts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SoldProducts", "ErrorMessage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SoldProducts", "ErrorMessage");
        }
    }
}
