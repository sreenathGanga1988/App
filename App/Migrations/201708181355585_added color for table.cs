namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcolorfortable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tables", "Color", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tables", "Color");
        }
    }
}
