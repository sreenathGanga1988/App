namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaddedshifttocredit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditMasters", "ShiftID", c => c.Int());
            CreateIndex("dbo.CreditMasters", "ShiftID");
            AddForeignKey("dbo.CreditMasters", "ShiftID", "dbo.Shifts", "ShiftID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditMasters", "ShiftID", "dbo.Shifts");
            DropIndex("dbo.CreditMasters", new[] { "ShiftID" });
            DropColumn("dbo.CreditMasters", "ShiftID");
        }
    }
}
