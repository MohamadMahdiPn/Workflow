namespace WorkflowENG.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBaseEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flows", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Flows", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Flows", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Flows", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Flows", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.SampleForms", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.SampleForms", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.SampleForms", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SampleForms", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.SampleForms", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.RolesForUsers", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.RolesForUsers", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.RolesForUsers", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.RolesForUsers", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.RolesForUsers", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Users", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Users", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "RowVersion");
            DropColumn("dbo.Users", "ModifiedDate");
            DropColumn("dbo.Users", "CreateDate");
            DropColumn("dbo.Users", "IsActive");
            DropColumn("dbo.Users", "IsDeleted");
            DropColumn("dbo.RolesForUsers", "RowVersion");
            DropColumn("dbo.RolesForUsers", "ModifiedDate");
            DropColumn("dbo.RolesForUsers", "CreateDate");
            DropColumn("dbo.RolesForUsers", "IsActive");
            DropColumn("dbo.RolesForUsers", "IsDeleted");
            DropColumn("dbo.SampleForms", "RowVersion");
            DropColumn("dbo.SampleForms", "ModifiedDate");
            DropColumn("dbo.SampleForms", "CreateDate");
            DropColumn("dbo.SampleForms", "IsActive");
            DropColumn("dbo.SampleForms", "IsDeleted");
            DropColumn("dbo.Flows", "RowVersion");
            DropColumn("dbo.Flows", "ModifiedDate");
            DropColumn("dbo.Flows", "CreateDate");
            DropColumn("dbo.Flows", "IsActive");
            DropColumn("dbo.Flows", "IsDeleted");
        }
    }
}
