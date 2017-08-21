namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedsettings : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.AppSettingID)
                .ForeignKey("dbo.Stores", t => t.StoreID)
                .Index(t => t.StoreID);
            
            CreateTable(
                "dbo.OdooDetails",
                c => new
                    {
                        OdooDetailID = c.Int(nullable: false, identity: true),
                        Server = c.String(),
                        PortNum = c.Int(nullable: false),
                        UserId = c.String(),
                        Password = c.String(),
                        DataBasename = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OdooDetailID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppSettings", "StoreID", "dbo.Stores");
            DropIndex("dbo.AppSettings", new[] { "StoreID" });
            DropTable("dbo.OdooDetails");
            DropTable("dbo.AppSettings");
        }
    }
}
