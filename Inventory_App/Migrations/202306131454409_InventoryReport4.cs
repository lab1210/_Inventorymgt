namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InventoryReport4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InventoryReports", "Sale_Id", "dbo.Sales");
            DropIndex("dbo.InventoryReports", new[] { "Sale_Id" });
            RenameColumn(table: "dbo.InventoryReports", name: "Sale_Id", newName: "SaleID");
            AlterColumn("dbo.InventoryReports", "SaleID", c => c.Int(nullable: false));
            CreateIndex("dbo.InventoryReports", "SaleID");
            AddForeignKey("dbo.InventoryReports", "SaleID", "dbo.Sales", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InventoryReports", "SaleID", "dbo.Sales");
            DropIndex("dbo.InventoryReports", new[] { "SaleID" });
            AlterColumn("dbo.InventoryReports", "SaleID", c => c.Int());
            RenameColumn(table: "dbo.InventoryReports", name: "SaleID", newName: "Sale_Id");
            CreateIndex("dbo.InventoryReports", "Sale_Id");
            AddForeignKey("dbo.InventoryReports", "Sale_Id", "dbo.Sales", "Id");
        }
    }
}
