namespace WorkflowENG.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editflows : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flows", "WorkflowSchemeName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flows", "WorkflowSchemeName");
        }
    }
}
