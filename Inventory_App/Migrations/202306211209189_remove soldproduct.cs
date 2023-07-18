namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removesoldproduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SoldProducts", "Sale_Id", "dbo.Sales");
            DropIndex("dbo.SoldProducts", new[] { "Sale_Id" });
            AddColumn("dbo.Sales", "quantity", c => c.Int(nullable: false));
            DropTable("dbo.SoldProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SoldProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sale_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.Sales", "quantity");
            CreateIndex("dbo.SoldProducts", "Sale_Id");
            AddForeignKey("dbo.SoldProducts", "Sale_Id", "dbo.Sales", "Id");
        }
    }
}
