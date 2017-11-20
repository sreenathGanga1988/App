namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedbuzerodooid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Buzzers", "OdooBuzzerID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Buzzers", "OdooBuzzerID");
        }
    }
}
