namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sadasdsasdq : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "OdooProductId", c => c.Int());
            AddColumn("dbo.Categories", "OdooCategoryId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "OdooCategoryId");
            DropColumn("dbo.Products", "OdooProductId");
        }
    }
}
