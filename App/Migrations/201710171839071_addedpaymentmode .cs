namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpaymentmode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoicemasters", "PaymentMode", c => c.String());
            AddColumn("dbo.Invoicemasters", "Buzzer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoicemasters", "Buzzer");
            DropColumn("dbo.Invoicemasters", "PaymentMode");
        }
    }
}
