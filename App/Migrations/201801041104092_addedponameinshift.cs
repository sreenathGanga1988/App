namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedponameinshift : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shifts", "PosName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shifts", "PosName");
        }
    }
}
