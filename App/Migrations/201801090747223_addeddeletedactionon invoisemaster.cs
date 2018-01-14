namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddeletedactiononinvoisemaster : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoicemasters", "DeletedBy", c => c.String());
            AddColumn("dbo.Invoicemasters", "DeletedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoicemasters", "DeletedDate");
            DropColumn("dbo.Invoicemasters", "DeletedBy");
        }
    }
}
