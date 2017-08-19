namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isratechangable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Color", c => c.String());
            AddColumn("dbo.Products", "Image", c => c.String());
            AddColumn("dbo.Products", "IsRateChangable", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "IsRateChangable");
            DropColumn("dbo.Products", "Image");
            DropColumn("dbo.Products", "Color");
        }
    }
}
