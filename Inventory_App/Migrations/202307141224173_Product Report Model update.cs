namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductReportModelupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductReports", "ProductID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductReports", "ProductID");
        }
    }
}
