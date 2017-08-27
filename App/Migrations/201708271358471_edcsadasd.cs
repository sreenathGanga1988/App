namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edcsadasd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoicemasters", "IsUploaded", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoicemasters", "IsUploaded");
        }
    }
}
