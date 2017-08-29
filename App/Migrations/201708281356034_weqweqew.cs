namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class weqweqew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoicemasters", "TotalBill", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Invoicemasters", "TotalDiscount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoicemasters", "TotalDiscount");
            DropColumn("dbo.Invoicemasters", "TotalBill");
        }
    }
}
