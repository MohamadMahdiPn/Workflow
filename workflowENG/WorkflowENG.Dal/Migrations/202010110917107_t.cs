namespace WorkflowENG.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class t : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RolesForUsers", "RolesForUsers_Id", "dbo.RolesForUsers");
            DropIndex("dbo.RolesForUsers", new[] { "RolesForUsers_Id" });
            DropColumn("dbo.RolesForUsers", "RolesForUsers_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RolesForUsers", "RolesForUsers_Id", c => c.Int());
            CreateIndex("dbo.RolesForUsers", "RolesForUsers_Id");
            AddForeignKey("dbo.RolesForUsers", "RolesForUsers_Id", "dbo.RolesForUsers", "Id");
        }
    }
}
