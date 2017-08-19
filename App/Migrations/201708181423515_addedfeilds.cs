namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfeilds : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ControlDiemensions", "ControlWidth", c => c.Int());
            AlterColumn("dbo.ControlDiemensions", "ControlHeight", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ControlDiemensions", "ControlHeight", c => c.Int(nullable: false));
            AlterColumn("dbo.ControlDiemensions", "ControlWidth", c => c.Int(nullable: false));
        }
    }
}
