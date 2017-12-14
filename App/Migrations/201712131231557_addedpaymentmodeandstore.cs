namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpaymentmodeandstore : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditMasters",
                c => new
                    {
                        CreditMasterID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        PaymentDue = c.Decimal(precision: 18, scale: 2),
                        InvoicemasterID = c.Int(nullable: false),
                        StoreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CreditMasterID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .ForeignKey("dbo.Invoicemasters", t => t.InvoicemasterID)
                .ForeignKey("dbo.Stores", t => t.StoreID)
                .Index(t => t.CustomerID)
                .Index(t => t.InvoicemasterID)
                .Index(t => t.StoreID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditMasters", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.CreditMasters", "InvoicemasterID", "dbo.Invoicemasters");
            DropForeignKey("dbo.CreditMasters", "CustomerID", "dbo.Customers");
            DropIndex("dbo.CreditMasters", new[] { "StoreID" });
            DropIndex("dbo.CreditMasters", new[] { "InvoicemasterID" });
            DropIndex("dbo.CreditMasters", new[] { "CustomerID" });
            DropTable("dbo.CreditMasters");
        }
    }
}
