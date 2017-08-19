namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        TableID = c.Int(nullable: false, identity: true),
                        StoreID = c.Int(nullable: false),
                        TableName = c.String(),
                    })
                .PrimaryKey(t => t.TableID)
                .ForeignKey("dbo.Stores", t => t.StoreID, cascadeDelete: true)
                .Index(t => t.StoreID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tables", "StoreID", "dbo.Stores");
            DropIndex("dbo.Tables", new[] { "StoreID" });
            DropTable("dbo.Tables");
        }
    }
}
