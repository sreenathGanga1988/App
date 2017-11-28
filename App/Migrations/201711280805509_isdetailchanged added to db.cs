namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isdetailchangedaddedtodb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsDetailChanged", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsDetailChanged");
        }
    }
}
