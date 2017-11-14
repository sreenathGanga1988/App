namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madeendtimeoptional : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Shifts", "EndTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shifts", "EndTime", c => c.DateTime(nullable: false));
        }
    }
}
