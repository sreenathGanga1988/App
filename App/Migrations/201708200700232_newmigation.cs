namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ControlDiemensions", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.Users", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.Customers", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.Tables", "StoreID", "dbo.Stores");
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        InvoiceDetailID = c.Int(nullable: false, identity: true),
                        InvoicemasterID = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Qty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountPerUOM = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsUploaded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceDetailID)
                .ForeignKey("dbo.Invoicemasters", t => t.InvoicemasterID)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.InvoicemasterID)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Invoicemasters",
                c => new
                    {
                        InvoicemasterID = c.Int(nullable: false, identity: true),
                        StoreID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        InvoiceDate = c.DateTime(nullable: false),
                        TotalPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RoundOffAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.InvoicemasterID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .ForeignKey("dbo.Stores", t => t.StoreID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.StoreID)
                .Index(t => t.UserID)
                .Index(t => t.CustomerID);
            
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id");
            AddForeignKey("dbo.ControlDiemensions", "StoreID", "dbo.Stores", "StoreID");
            AddForeignKey("dbo.Users", "StoreID", "dbo.Stores", "StoreID");
            AddForeignKey("dbo.Customers", "StoreID", "dbo.Stores", "StoreID");
            AddForeignKey("dbo.Tables", "StoreID", "dbo.Stores", "StoreID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tables", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.Customers", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.Users", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.ControlDiemensions", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.InvoiceDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Invoicemasters", "UserID", "dbo.Users");
            DropForeignKey("dbo.InvoiceDetails", "InvoicemasterID", "dbo.Invoicemasters");
            DropForeignKey("dbo.Invoicemasters", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.Invoicemasters", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Invoicemasters", new[] { "CustomerID" });
            DropIndex("dbo.Invoicemasters", new[] { "UserID" });
            DropIndex("dbo.Invoicemasters", new[] { "StoreID" });
            DropIndex("dbo.InvoiceDetails", new[] { "ProductId" });
            DropIndex("dbo.InvoiceDetails", new[] { "InvoicemasterID" });
            DropTable("dbo.Invoicemasters");
            DropTable("dbo.InvoiceDetails");
            AddForeignKey("dbo.Tables", "StoreID", "dbo.Stores", "StoreID", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "StoreID", "dbo.Stores", "StoreID", cascadeDelete: true);
            AddForeignKey("dbo.Users", "StoreID", "dbo.Stores", "StoreID", cascadeDelete: true);
            AddForeignKey("dbo.ControlDiemensions", "StoreID", "dbo.Stores", "StoreID", cascadeDelete: true);
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
