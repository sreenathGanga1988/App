namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedisactive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Isactive", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Isactive");
        }
    }
}
