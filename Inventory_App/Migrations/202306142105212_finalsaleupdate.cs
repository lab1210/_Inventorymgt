namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finalsaleupdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SoldProducts", "Unit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SoldProducts", "Unit", c => c.String());
        }
    }
}
