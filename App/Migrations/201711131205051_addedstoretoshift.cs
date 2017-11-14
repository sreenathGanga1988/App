namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedstoretoshift : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shifts", "StoreID", c => c.Int(nullable: false));
            CreateIndex("dbo.Shifts", "StoreID");
            AddForeignKey("dbo.Shifts", "StoreID", "dbo.Stores", "StoreID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shifts", "StoreID", "dbo.Stores");
            DropIndex("dbo.Shifts", new[] { "StoreID" });
            DropColumn("dbo.Shifts", "StoreID");
        }
    }
}
