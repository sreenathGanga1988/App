namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OdooDetails", "StoreID", c => c.Int(nullable: false));
            CreateIndex("dbo.OdooDetails", "StoreID");
            AddForeignKey("dbo.OdooDetails", "StoreID", "dbo.Stores", "StoreID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OdooDetails", "StoreID", "dbo.Stores");
            DropIndex("dbo.OdooDetails", new[] { "StoreID" });
            DropColumn("dbo.OdooDetails", "StoreID");
        }
    }
}
