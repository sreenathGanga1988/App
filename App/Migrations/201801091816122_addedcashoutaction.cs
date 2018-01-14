namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcashoutaction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CashOutMasters",
                c => new
                    {
                        CashOutMasterID = c.Int(nullable: false, identity: true),
                        CashOutNum = c.String(),
                        StoreID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        ShiftID = c.Int(),
                        CashOutDate = c.DateTime(nullable: false),
                        TotalCashOut = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Approvedby = c.String(),
                        CashOutType = c.String(),
                    })
                .PrimaryKey(t => t.CashOutMasterID)
                .ForeignKey("dbo.Shifts", t => t.ShiftID)
                .ForeignKey("dbo.Stores", t => t.StoreID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.StoreID)
                .Index(t => t.UserID)
                .Index(t => t.ShiftID);
            
            AddColumn("dbo.RefundMasters", "Approvedby", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CashOutMasters", "UserID", "dbo.Users");
            DropForeignKey("dbo.CashOutMasters", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.CashOutMasters", "ShiftID", "dbo.Shifts");
            DropIndex("dbo.CashOutMasters", new[] { "ShiftID" });
            DropIndex("dbo.CashOutMasters", new[] { "UserID" });
            DropIndex("dbo.CashOutMasters", new[] { "StoreID" });
            DropColumn("dbo.RefundMasters", "Approvedby");
            DropTable("dbo.CashOutMasters");
        }
    }
}
