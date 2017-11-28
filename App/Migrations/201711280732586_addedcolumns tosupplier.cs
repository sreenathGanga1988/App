namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcolumnstosupplier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "AddedBy", c => c.String());
            AddColumn("dbo.Customers", "AddedDate", c => c.String());
            AddColumn("dbo.Customers", "OdooID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "OdooID");
            DropColumn("dbo.Customers", "AddedDate");
            DropColumn("dbo.Customers", "AddedBy");
        }
    }
}
