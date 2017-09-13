namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedistanlebill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoicemasters", "IstableBill", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoicemasters", "IstableBill");
        }
    }
}
