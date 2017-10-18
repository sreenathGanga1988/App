namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtodayspecial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "IsTodaySpecial", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "IsTodaySpecial");
        }
    }
}
