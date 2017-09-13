namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedkotprintedoption : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KotDetails", "IsPrinted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KotDetails", "IsPrinted");
        }
    }
}
