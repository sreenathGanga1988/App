namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedprinterandmaster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Printers",
                c => new
                    {
                        PrinterId = c.Int(nullable: false, identity: true),
                        PrinterName = c.String(),
                        Remark = c.String(),
                        StoreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrinterId)
                .ForeignKey("dbo.Stores", t => t.StoreID)
                .Index(t => t.StoreID);
            
            AddColumn("dbo.Categories", "PrinterId", c => c.Int());
            CreateIndex("dbo.Categories", "PrinterId");
            AddForeignKey("dbo.Categories", "PrinterId", "dbo.Printers", "PrinterId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Printers", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.Categories", "PrinterId", "dbo.Printers");
            DropIndex("dbo.Printers", new[] { "StoreID" });
            DropIndex("dbo.Categories", new[] { "PrinterId" });
            DropColumn("dbo.Categories", "PrinterId");
            DropTable("dbo.Printers");
        }
    }
}
