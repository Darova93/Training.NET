namespace Softtek.Academy2018.Demo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingProjects : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProjectUsers", newName: "UserProjects");
            DropPrimaryKey("dbo.UserProjects");
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false));
            AddPrimaryKey("dbo.UserProjects", new[] { "User_Id", "Project_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserProjects");
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            DropTable("dbo.Roles");
            AddPrimaryKey("dbo.UserProjects", new[] { "Project_Id", "User_Id" });
            RenameTable(name: "dbo.UserProjects", newName: "ProjectUsers");
        }
    }
}
