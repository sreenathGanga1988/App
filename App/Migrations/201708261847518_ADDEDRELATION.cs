namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDEDRELATION : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoicemasters", "TableID", c => c.Int(nullable: false));
            AddColumn("dbo.KotMasters", "TableID", c => c.Int(nullable: false));
            CreateIndex("dbo.Invoicemasters", "TableID");
            CreateIndex("dbo.KotMasters", "TableID");
            AddForeignKey("dbo.Invoicemasters", "TableID", "dbo.Tables", "TableID");
            AddForeignKey("dbo.KotMasters", "TableID", "dbo.Tables", "TableID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KotMasters", "TableID", "dbo.Tables");
            DropForeignKey("dbo.Invoicemasters", "TableID", "dbo.Tables");
            DropIndex("dbo.KotMasters", new[] { "TableID" });
            DropIndex("dbo.Invoicemasters", new[] { "TableID" });
            DropColumn("dbo.KotMasters", "TableID");
            DropColumn("dbo.Invoicemasters", "TableID");
        }
    }
}
