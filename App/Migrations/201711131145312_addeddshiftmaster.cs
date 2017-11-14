namespace App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddshiftmaster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        ShiftID = c.Int(nullable: false, identity: true),
                        ShiftName = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        IsClosed = c.Boolean(),
                        StartUserName = c.String(),
                        CloseUserName = c.String(),
                    })
                .PrimaryKey(t => t.ShiftID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Shifts");
        }
    }
}
