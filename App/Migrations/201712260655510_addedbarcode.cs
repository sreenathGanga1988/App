namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedbarcode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BarcodeNum", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BarcodeNum");
        }
    }
}
