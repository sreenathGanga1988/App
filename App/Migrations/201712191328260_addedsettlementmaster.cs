namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedsettlementmaster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SettleMasters",
                c => new
                    {
                        SettleMasterID = c.Int(nullable: false, identity: true),
                        StoreID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        ShiftID = c.Int(),
                        CustomerID = c.Int(nullable: false),
                        SettleDate = c.DateTime(nullable: false),
                        TotalRefund = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SettleMasterID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .ForeignKey("dbo.Shifts", t => t.ShiftID)
                .ForeignKey("dbo.Stores", t => t.StoreID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.StoreID)
                .Index(t => t.UserID)
                .Index(t => t.ShiftID)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SettleMasters", "UserID", "dbo.Users");
            DropForeignKey("dbo.SettleMasters", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.SettleMasters", "ShiftID", "dbo.Shifts");
            DropForeignKey("dbo.SettleMasters", "CustomerID", "dbo.Customers");
            DropIndex("dbo.SettleMasters", new[] { "CustomerID" });
            DropIndex("dbo.SettleMasters", new[] { "ShiftID" });
            DropIndex("dbo.SettleMasters", new[] { "UserID" });
            DropIndex("dbo.SettleMasters", new[] { "StoreID" });
            DropTable("dbo.SettleMasters");
        }
    }
}
