namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addetatoproduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Taxamount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Taxamount");
        }
    }
}
