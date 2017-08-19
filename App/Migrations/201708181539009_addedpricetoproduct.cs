namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpricetoproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "UnitPrice", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Products", "DiscountForLocation", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Products", "MinimumSPForLocation", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "MinimumSPForLocation");
            DropColumn("dbo.Products", "DiscountForLocation");
            DropColumn("dbo.Products", "UnitPrice");
        }
    }
}
