namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddodooupdaterids : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tables", "OdooTableID", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "OdooUserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "OdooUserID");
            DropColumn("dbo.Tables", "OdooTableID");
        }
    }
}
