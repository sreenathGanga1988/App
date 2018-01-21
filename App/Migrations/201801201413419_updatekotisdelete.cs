namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatekotisdelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KotDetails", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KotDetails", "IsDeleted");
        }
    }
}
