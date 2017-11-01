namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpaymenttremidansvalue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoicemasters", "PayMentModeId", c => c.Int(nullable: false));
            AddColumn("dbo.Invoicemasters", "TableName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoicemasters", "TableName");
            DropColumn("dbo.Invoicemasters", "PayMentModeId");
        }
    }
}
