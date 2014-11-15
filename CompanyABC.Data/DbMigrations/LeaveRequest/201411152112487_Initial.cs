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
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "UC_Name");
            
            CreateTable(
                "LeaveRequest.l_UserRole",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "UC_Name");
            
            CreateTable(
                "LeaveRequest.m_User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        UserRoleId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("LeaveRequest.l_UserRole", t => t.UserRoleId, cascadeDelete: true)
                .Index(t => t.Username, unique: true, name: "UC_Username")
                .Index(t => t.UserRoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("LeaveRequest.m_User", "UserRoleId", "LeaveRequest.l_UserRole");
            DropIndex("LeaveRequest.m_User", new[] { "UserRoleId" });
            DropIndex("LeaveRequest.m_User", "UC_Username");
            DropIndex("LeaveRequest.l_UserRole", "UC_Name");
            DropIndex("LeaveRequest.l_Reason", "UC_Name");
            DropTable("LeaveRequest.m_User");
            DropTable("LeaveRequest.l_UserRole");
            DropTable("LeaveRequest.l_Reason");
        }
    }
}
