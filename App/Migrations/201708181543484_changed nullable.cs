namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changednullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "DiscountForLocation", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "MinimumSPForLocation", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "MinimumSPForLocation", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Products", "DiscountForLocation", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Products", "UnitPrice", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
