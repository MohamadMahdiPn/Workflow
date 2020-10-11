namespace WorkflowENG.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstAndStart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SampleFormId = c.Int(nullable: false),
                        WorkflowInstanceId = c.Guid(nullable: false),
                        CurrentStateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SampleForms", t => t.SampleFormId, cascadeDelete: true)
                .Index(t => t.SampleFormId);
            
            CreateTable(
                "dbo.SampleForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RolesForUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        ParentId = c.Int(nullable: false),
                        RolesForUsers_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RolesForUsers", t => t.RolesForUsers_Id)
                .Index(t => t.RolesForUsers_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Family = c.String(),
                        RoleId = c.Int(nullable: false),
                        GUID = c.Guid(nullable: false),
                        roles_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RolesForUsers", t => t.roles_Id)
                .Index(t => t.roles_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "roles_Id", "dbo.RolesForUsers");
            DropForeignKey("dbo.RolesForUsers", "RolesForUsers_Id", "dbo.RolesForUsers");
            DropForeignKey("dbo.Flows", "SampleFormId", "dbo.SampleForms");
            DropIndex("dbo.Users", new[] { "roles_Id" });
            DropIndex("dbo.RolesForUsers", new[] { "RolesForUsers_Id" });
            DropIndex("dbo.Flows", new[] { "SampleFormId" });
            DropTable("dbo.Users");
            DropTable("dbo.RolesForUsers");
            DropTable("dbo.SampleForms");
            DropTable("dbo.Flows");
        }
    }
}
