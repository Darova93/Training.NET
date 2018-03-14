namespace Softtek.Academy.Final.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class configurations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Answers", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Options", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Options", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Questions", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Questions", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.QuestionTypes", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.QuestionTypes", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Surveys", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Answers", "OpenText", c => c.String(maxLength: 300));
            AlterColumn("dbo.Answers", "Guest", c => c.String(maxLength: 100));
            AlterColumn("dbo.Options", "Text", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Questions", "Text", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.QuestionTypes", "Description", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Surveys", "Title", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Surveys", "Description", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Surveys", "Description", c => c.String());
            AlterColumn("dbo.Surveys", "Title", c => c.String());
            AlterColumn("dbo.QuestionTypes", "Description", c => c.String());
            AlterColumn("dbo.Questions", "Text", c => c.String());
            AlterColumn("dbo.Options", "Text", c => c.String());
            AlterColumn("dbo.Answers", "Guest", c => c.String());
            AlterColumn("dbo.Answers", "OpenText", c => c.String());
            DropColumn("dbo.Surveys", "ModifiedDate");
            DropColumn("dbo.QuestionTypes", "ModifiedDate");
            DropColumn("dbo.QuestionTypes", "CreatedDate");
            DropColumn("dbo.Questions", "ModifiedDate");
            DropColumn("dbo.Questions", "CreatedDate");
            DropColumn("dbo.Options", "ModifiedDate");
            DropColumn("dbo.Options", "CreatedDate");
            DropColumn("dbo.Answers", "ModifiedDate");
            DropColumn("dbo.Answers", "CreatedDate");
        }
    }
}
