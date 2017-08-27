namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsdasd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AppSettings", "StoreID", "dbo.Stores");
            DropIndex("dbo.AppSettings", new[] { "StoreID" });
            CreateTable(
                "dbo.AppUserSettings",
                c => new
                    {
                        AppUserSettingID = c.Int(nullable: false, identity: true),
                        ProductperRow = c.Int(nullable: false),
                        InvoicePrefix = c.String(),
                        PaddingNumber = c.Int(nullable: false),
                        ProductButtonWidth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductButtonHeigth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StoreID = c.Int(nullable: false),
                        RealtimeInvoiceUpdate = c.Boolean(nullable: false),
                        FastLoading = c.Boolean(nullable: false),
                        AutoSizebutton = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AppUserSettingID)
                .ForeignKey("dbo.Stores", t => t.StoreID)
                .Index(t => t.StoreID);
            
            DropTable("dbo.AppSettings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AppSettings",
                c => new
                    {
                        AppSettingID = c.Int(nullable: false, identity: true),
                        StoreID = c.Int(nullable: false),
                        RealtimeInvoiceUpdate = c.Boolean(nullable: false),
                        FastLoadingofProduct = c.Boolean(nullable: false),
                        NoofproductonRow = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AppSettingID);
            
            DropForeignKey("dbo.AppUserSettings", "StoreID", "dbo.Stores");
            DropIndex("dbo.AppUserSettings", new[] { "StoreID" });
            DropTable("dbo.AppUserSettings");
            CreateIndex("dbo.AppSettings", "StoreID");
            AddForeignKey("dbo.AppSettings", "StoreID", "dbo.Stores", "StoreID");
        }
    }
}
