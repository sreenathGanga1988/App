namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hhgdhfdjh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buzzers",
                c => new
                    {
                        BuzzerID = c.Int(nullable: false, identity: true),
                        StoreID = c.Int(nullable: false),
                        BuzzerName = c.String(),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.BuzzerID)
                .ForeignKey("dbo.Stores", t => t.StoreID)
                .Index(t => t.StoreID);
            
            AddColumn("dbo.Invoicemasters", "BuzzerName", c => c.String());
            AddColumn("dbo.Invoicemasters", "BuzzerID", c => c.Int());
            CreateIndex("dbo.Invoicemasters", "BuzzerID");
            AddForeignKey("dbo.Invoicemasters", "BuzzerID", "dbo.Buzzers", "BuzzerID");
            DropColumn("dbo.Invoicemasters", "Buzzer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoicemasters", "Buzzer", c => c.String());
            DropForeignKey("dbo.Buzzers", "StoreID", "dbo.Stores");
            DropForeignKey("dbo.Invoicemasters", "BuzzerID", "dbo.Buzzers");
            DropIndex("dbo.Invoicemasters", new[] { "BuzzerID" });
            DropIndex("dbo.Buzzers", new[] { "StoreID" });
            DropColumn("dbo.Invoicemasters", "BuzzerID");
            DropColumn("dbo.Invoicemasters", "BuzzerName");
            DropTable("dbo.Buzzers");
        }
    }
}
