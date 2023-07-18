namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesales2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SelectedProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Sale_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sales", t => t.Sale_Id)
                .Index(t => t.Sale_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SelectedProducts", "Sale_Id", "dbo.Sales");
            DropIndex("dbo.SelectedProducts", new[] { "Sale_Id" });
            DropTable("dbo.SelectedProducts");
        }
    }
}
