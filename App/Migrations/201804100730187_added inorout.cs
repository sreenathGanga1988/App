namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedinorout : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CashOutMasters", "InOrOut", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CashOutMasters", "InOrOut");
        }
    }
}
