namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedstoredbid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "StoreDBId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stores", "StoreDBId");
        }
    }
}
