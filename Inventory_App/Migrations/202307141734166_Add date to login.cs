namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adddatetologin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "LoggedInDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logins", "LoggedInDate");
        }
    }
}
