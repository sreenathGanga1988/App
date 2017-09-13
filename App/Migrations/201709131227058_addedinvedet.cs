namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedinvedet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceDetails", "IsDeleted", c => c.Boolean());
            AddColumn("dbo.InvoiceDetails", "PreviousQty", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.InvoiceDetails", "AdjustedQty", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InvoiceDetails", "AdjustedQty");
            DropColumn("dbo.InvoiceDetails", "PreviousQty");
            DropColumn("dbo.InvoiceDetails", "IsDeleted");
        }
    }
}
