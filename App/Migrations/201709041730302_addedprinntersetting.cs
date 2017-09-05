namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedprinntersetting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PrinterDetails",
                c => new
                    {
                        PrinterDetailId = c.Int(nullable: false, identity: true),
                        PosPrinter = c.String(),
                        KotPrinter = c.String(),
                        JuicePrinter = c.String(),
                        StoreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrinterDetailId)
                .ForeignKey("dbo.Stores", t => t.StoreID)
                .Index(t => t.StoreID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrinterDetails", "StoreID", "dbo.Stores");
            DropIndex("dbo.PrinterDetails", new[] { "StoreID" });
            DropTable("dbo.PrinterDetails");
        }
    }
}
