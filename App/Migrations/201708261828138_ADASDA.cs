namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADASDA : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KotDetails", "ProductName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.KotDetails", "ProductName");
        }
    }
}
