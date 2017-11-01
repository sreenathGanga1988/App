namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsomething : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentModeMasters",
                c => new
                    {
                        PaymentModeID = c.Int(nullable: false, identity: true),
                        PaymentMode = c.String(),
                    })
                .PrimaryKey(t => t.PaymentModeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PaymentModeMasters");
        }
    }
}
