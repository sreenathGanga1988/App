namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeduserconfguration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppUserSettings", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppUserSettings", "IsActive");
        }
    }
}
