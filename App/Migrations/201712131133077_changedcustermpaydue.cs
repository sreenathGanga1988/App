namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedcustermpaydue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "PaymentDue", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "PaymentDue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
