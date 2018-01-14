namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refundandcashoutchange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RefundMasters", "IsUploaded", c => c.Boolean(nullable: false));
            AddColumn("dbo.CashOutMasters", "IsUploaded", c => c.Boolean(nullable: false));
            AddColumn("dbo.SettleMasters", "IsUploaded", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SettleMasters", "IsUploaded");
            DropColumn("dbo.CashOutMasters", "IsUploaded");
            DropColumn("dbo.RefundMasters", "IsUploaded");
        }
    }
}
