namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateadsad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RefundMasters",
                c => new
                    {
                        RefundMasterID = c.Int(nullable: false, identity: true),
                        RefundNum = c.String(),
                        StoreID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        InvoicemasterID = c.Int(nullable: false),
                        RefundDate = c.DateTime(nullable: false),
                        TotalRefund = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.RefundMasterID)
                .ForeignKey("dbo.Invoicemasters", t => t.InvoicemasterID)
                .ForeignKey("dbo.Stores", t => t.StoreID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.StoreID)
                .Index(t => t.UserID)
                .Index(t => t.InvoicemasterID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RefundMasters", "UserID", "dbo.Users");
            DropForeignKey("dbo.RefundMasters", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.RefundMasters", "InvoicemasterID", "dbo.Invoicemasters");
            DropIndex("dbo.RefundMasters", new[] { "InvoicemasterID" });
            DropIndex("dbo.RefundMasters", new[] { "UserID" });
            DropIndex("dbo.RefundMasters", new[] { "StoreID" });
            DropTable("dbo.RefundMasters");
        }
    }
}
