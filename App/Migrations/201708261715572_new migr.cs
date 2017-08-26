namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoicemasters", "KotMasterID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoicemasters", "KotMasterID");
        }
    }
}
