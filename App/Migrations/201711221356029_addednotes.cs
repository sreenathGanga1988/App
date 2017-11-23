namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceDetails", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InvoiceDetails", "Notes");
        }
    }
}
