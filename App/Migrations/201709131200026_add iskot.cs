namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addiskot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoicemasters", "IsKOT", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoicemasters", "IsKOT");
        }
    }
}
