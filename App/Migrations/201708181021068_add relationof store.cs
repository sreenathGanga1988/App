namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrelationofstore : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Users", "StoreID");
            AddForeignKey("dbo.Users", "StoreID", "dbo.Stores", "StoreID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "StoreID", "dbo.Stores");
            DropIndex("dbo.Users", new[] { "StoreID" });
        }
    }
}
