﻿namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unitaddedtosale1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SoldProducts", "Unit", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SoldProducts", "Unit");
        }
    }
}
