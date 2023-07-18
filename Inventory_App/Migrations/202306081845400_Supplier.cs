namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Supplier : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Suppliers",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    name = c.String(nullable: false),
                    phone = c.String(nullable: false),
                    Email = c.String(nullable: false),
                    Address = c.String(nullable: false),
                    
                })
                .PrimaryKey(t => t.id);
              
        }
        
        public override void Down()
        {
            
            DropTable("dbo.Suppliers");
        }
    }
}
