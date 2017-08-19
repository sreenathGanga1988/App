namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcontroldiemension : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ControlDiemensions",
                c => new
                    {
                        ControlDiemensionID = c.Int(nullable: false, identity: true),
                        ControlName = c.String(maxLength: 20),
                        ControlDescription = c.String(),
                        ControlWidth = c.Int(nullable: false),
                        ControlHeight = c.Int(nullable: false),
                        StoreID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ControlDiemensionID)
                .ForeignKey("dbo.Stores", t => t.StoreID, cascadeDelete: true)
                .Index(t => t.StoreID);
            
           
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ControlDiemensions", "StoreID", "dbo.Stores");
            DropIndex("dbo.ControlDiemensions", new[] { "StoreID" });
            DropColumn("dbo.Categories", "Color");
            DropTable("dbo.ControlDiemensions");
        }
    }
}
