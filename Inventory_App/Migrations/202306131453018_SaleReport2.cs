namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaleReport2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SalesReports", "Sale_Id", "dbo.Sales");
            DropIndex("dbo.SalesReports", new[] { "Sale_Id" });
            RenameColumn(table: "dbo.SalesReports", name: "Sale_Id", newName: "SaleID");
            AlterColumn("dbo.SalesReports", "SaleID", c => c.Int(nullable: false));
            CreateIndex("dbo.SalesReports", "SaleID");
            AddForeignKey("dbo.SalesReports", "SaleID", "dbo.Sales", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesReports", "SaleID", "dbo.Sales");
            DropIndex("dbo.SalesReports", new[] { "SaleID" });
            AlterColumn("dbo.SalesReports", "SaleID", c => c.Int());
            RenameColumn(table: "dbo.SalesReports", name: "SaleID", newName: "Sale_Id");
            CreateIndex("dbo.SalesReports", "Sale_Id");
            AddForeignKey("dbo.SalesReports", "Sale_Id", "dbo.Sales", "Id");
        }
    }
}
