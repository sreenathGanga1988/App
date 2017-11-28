namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class optionalshiftid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoicemasters", "ShiftID", c => c.Int());
            AddColumn("dbo.Shifts", "OdooShiftId", c => c.Int(nullable: false));
            CreateIndex("dbo.Invoicemasters", "ShiftID");
            AddForeignKey("dbo.Invoicemasters", "ShiftID", "dbo.Shifts", "ShiftID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoicemasters", "ShiftID", "dbo.Shifts");
            DropIndex("dbo.Invoicemasters", new[] { "ShiftID" });
            DropColumn("dbo.Shifts", "OdooShiftId");
            DropColumn("dbo.Invoicemasters", "ShiftID");
        }
    }
}
