namespace Softtek.Academy.Final.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class data : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Surveys", "IsArchived", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Options", "Value", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Options", "Value", c => c.Int(nullable: false));
            DropColumn("dbo.Surveys", "IsArchived");
        }
    }
}
