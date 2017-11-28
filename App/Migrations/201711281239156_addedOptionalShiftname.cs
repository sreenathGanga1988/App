namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedOptionalShiftname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoicemasters", "ShiftName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoicemasters", "ShiftName");
        }
    }
}
