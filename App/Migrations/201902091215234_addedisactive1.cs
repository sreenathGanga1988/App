namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedisactive1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Isactive", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Isactive");
        }
    }
}
