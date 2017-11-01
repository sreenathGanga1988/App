namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedislockedto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buzzers", "IsLocked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buzzers", "IsLocked");
        }
    }
}
