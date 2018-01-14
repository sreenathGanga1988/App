namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateonstore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "Street", c => c.String());
            AddColumn("dbo.Stores", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stores", "Phone");
            DropColumn("dbo.Stores", "Street");
        }
    }
}
