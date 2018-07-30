namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedremark : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RefundMasters", "Remark", c => c.String());
            AddColumn("dbo.CashOutMasters", "Remark", c => c.String());
            AddColumn("dbo.CreditMasters", "Remark", c => c.String());
            AddColumn("dbo.SettleMasters", "Remark", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SettleMasters", "Remark");
            DropColumn("dbo.CreditMasters", "Remark");
            DropColumn("dbo.CashOutMasters", "Remark");
            DropColumn("dbo.RefundMasters", "Remark");
        }
    }
}
