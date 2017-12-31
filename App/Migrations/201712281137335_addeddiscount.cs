namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddiscount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Discount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Discount");
        }
    }
}
