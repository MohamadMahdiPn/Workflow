namespace WorkflowENG.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edirflow2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Flows", "CurrentStateId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Flows", "CurrentStateId", c => c.Int(nullable: false));
        }
    }
}
