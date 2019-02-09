namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedreportlogo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppUserSettings", "LogoReport", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppUserSettings", "LogoReport");
        }
    }
}
