namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addetaamounttoinvoice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoicemasters", "Taxamount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoicemasters", "Taxamount");
        }
    }
}
