namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KotDetails",
                c => new
                    {
                        KotDetailID = c.Int(nullable: false, identity: true),
                        KotMasterID = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPerUOM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsUploaded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.KotDetailID)
                .ForeignKey("dbo.KotMasters", t => t.KotMasterID)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.KotMasterID)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.KotMasters",
                c => new
                    {
                        KotMasterID = c.Int(nullable: false, identity: true),
                        StoreID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        InvoiceDate = c.DateTime(nullable: false),
                        TotalPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RoundOffAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.KotMasterID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .ForeignKey("dbo.Stores", t => t.StoreID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.StoreID)
                .Index(t => t.UserID)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KotDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.KotMasters", "UserID", "dbo.Users");
            DropForeignKey("dbo.KotMasters", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.KotDetails", "KotMasterID", "dbo.KotMasters");
            DropForeignKey("dbo.KotMasters", "CustomerID", "dbo.Customers");
            DropIndex("dbo.KotMasters", new[] { "CustomerID" });
            DropIndex("dbo.KotMasters", new[] { "UserID" });
            DropIndex("dbo.KotMasters", new[] { "StoreID" });
            DropIndex("dbo.KotDetails", new[] { "ProductId" });
            DropIndex("dbo.KotDetails", new[] { "KotMasterID" });
            DropTable("dbo.KotMasters");
            DropTable("dbo.KotDetails");
        }
    }
}
