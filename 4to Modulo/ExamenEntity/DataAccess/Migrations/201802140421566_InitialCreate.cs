namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 200),
                        IsArchived = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 200),
                        Priority = c.Int(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        IsArchived = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId);
            
            CreateTable(
                "dbo.ItemTags",
                c => new
                    {
                        TaskId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TaskId, t.TagId })
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.TaskId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.ItemTags", "TaskId", "dbo.Tasks");
            DropIndex("dbo.ItemTags", new[] { "TagId" });
            DropIndex("dbo.ItemTags", new[] { "TaskId" });
            DropTable("dbo.ItemTags");
            DropTable("dbo.Tasks");
            DropTable("dbo.Tags");
        }
    }
}
