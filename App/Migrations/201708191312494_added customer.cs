namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        StoreID = c.Int(nullable: false),
                        CustomerName = c.String(),
                        PhoneNumber = c.String(),
                        CustomerDetails = c.String(),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Stores", t => t.StoreID, cascadeDelete: true)
                .Index(t => t.StoreID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "StoreID", "dbo.Stores");
            DropIndex("dbo.Customers", new[] { "StoreID" });
            DropTable("dbo.Customers");
        }
    }
}
