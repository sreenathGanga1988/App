
namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedisdeletedtoinvoicemater : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoicemasters", "IsDeleted", c => c.Boolean());
            AddColumn("dbo.RefundMasters", "ShiftID", c => c.Int());
            CreateIndex("dbo.RefundMasters", "ShiftID");
            AddForeignKey("dbo.RefundMasters", "ShiftID", "dbo.Shifts", "ShiftID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RefundMasters", "ShiftID", "dbo.Shifts");
            DropIndex("dbo.RefundMasters", new[] { "ShiftID" });
            DropColumn("dbo.RefundMasters", "ShiftID");
            DropColumn("dbo.Invoicemasters", "IsDeleted");
        }
    }
}
