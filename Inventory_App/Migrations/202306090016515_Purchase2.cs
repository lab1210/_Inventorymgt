﻿namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Purchase2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PurchaseProducts", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseProducts", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
