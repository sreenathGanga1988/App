namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.Int(nullable: false));
        }
    }
}
