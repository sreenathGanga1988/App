namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedkotprefix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppUserSettings", "KotPrefix", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppUserSettings", "KotPrefix");
        }
    }
}
