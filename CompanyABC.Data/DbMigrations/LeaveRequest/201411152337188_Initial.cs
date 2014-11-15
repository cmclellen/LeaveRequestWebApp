namespace CompanyABC.Data.DbMigrations.LeaveRequest
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "LeaveRequest.m_LeaveRequest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        StartDate = c.String(nullable: false, maxLength: 4000),
                        EndDate = c.String(nullable: false, maxLength: 4000),
                        ReasonId = c.Int(nullable: false),
                        Comments = c.String(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("LeaveRequest.l_Reason", t => t.ReasonId, cascadeDelete: true)
                .ForeignKey("LeaveRequest.m_User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ReasonId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("LeaveRequest.m_LeaveRequest", "UserId", "LeaveRequest.m_User");
            DropForeignKey("LeaveRequest.m_User", "UserRoleId", "LeaveRequest.l_UserRole");
            DropForeignKey("LeaveRequest.m_LeaveRequest", "ReasonId", "LeaveRequest.l_Reason");
            DropIndex("LeaveRequest.l_UserRole", "UC_Name");
            DropIndex("LeaveRequest.m_User", new[] { "UserRoleId" });
            DropIndex("LeaveRequest.m_User", "UC_Username");
            DropIndex("LeaveRequest.l_Reason", "UC_Name");
            DropIndex("LeaveRequest.m_LeaveRequest", new[] { "ReasonId" });
            DropIndex("LeaveRequest.m_LeaveRequest", new[] { "UserId" });
            DropTable("LeaveRequest.l_UserRole");
            DropTable("LeaveRequest.m_User");
            DropTable("LeaveRequest.l_Reason");
            DropTable("LeaveRequest.m_LeaveRequest");
        }
    }
}
