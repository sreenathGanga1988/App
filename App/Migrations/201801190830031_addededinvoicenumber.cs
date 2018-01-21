namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addededinvoicenumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceDetails", "Kotnum", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InvoiceDetails", "Kotnum");
        }
    }
}
