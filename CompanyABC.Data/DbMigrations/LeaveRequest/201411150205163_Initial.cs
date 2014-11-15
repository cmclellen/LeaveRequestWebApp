namespace CompanyABC.Data.DbMigrations.LeaveRequest
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "LeaveRequest.l_Reason",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayName = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.DisplayName, unique: true, name: "UC_DisplayName");
            
        }
        
        public override void Down()
        {
            DropIndex("LeaveRequest.l_Reason", "UC_DisplayName");
            DropTable("LeaveRequest.l_Reason");
        }
    }
}
