namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaleReport1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SalesReports", new[] { "Sale_Id" });
            AlterColumn("dbo.SalesReports", "Sale_Id", c => c.Int());
            CreateIndex("dbo.SalesReports", "Sale_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.SalesReports", new[] { "Sale_Id" });
            AlterColumn("dbo.SalesReports", "Sale_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.SalesReports", "Sale_Id");
        }
    }
}
