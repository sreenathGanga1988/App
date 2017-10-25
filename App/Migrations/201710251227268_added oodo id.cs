namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedoodoid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "OdooStoreId", c => c.Int());
            AddColumn("dbo.Products", "OdooCategoryId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "OdooCategoryId");
            DropColumn("dbo.Stores", "OdooStoreId");
        }
    }
}
