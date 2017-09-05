namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invoiceandkotnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoicemasters", "InvoiceNum", c => c.String());
            AddColumn("dbo.KotMasters", "KotNum", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.KotMasters", "KotNum");
            DropColumn("dbo.Invoicemasters", "InvoiceNum");
        }
    }
}
