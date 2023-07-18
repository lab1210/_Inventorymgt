namespace Inventory_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Imagepathaddedtocategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ImagePath", c => c.String());
            DropColumn("dbo.Categories", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "Image", c => c.String());
            DropColumn("dbo.Categories", "ImagePath");
        }
    }
}
