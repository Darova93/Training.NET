namespace DataAccessEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Options",
                c => new
                    {
                        OptionId = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.OptionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 200),
                        QuestionTypeId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsRequired = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionId)
                .ForeignKey("dbo.QuestionTypes", t => t.QuestionTypeId, cascadeDelete: true)
                .Index(t => t.QuestionTypeId);
            
            CreateTable(
                "dbo.QuestionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuestionOptions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false),
                        OptionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestionId, t.OptionID })
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Options", t => t.OptionID, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.OptionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "QuestionTypeId", "dbo.QuestionTypes");
            DropForeignKey("dbo.QuestionOptions", "OptionID", "dbo.Options");
            DropForeignKey("dbo.QuestionOptions", "QuestionId", "dbo.Questions");
            DropIndex("dbo.QuestionOptions", new[] { "OptionID" });
            DropIndex("dbo.QuestionOptions", new[] { "QuestionId" });
            DropIndex("dbo.Questions", new[] { "QuestionTypeId" });
            DropTable("dbo.QuestionOptions");
            DropTable("dbo.QuestionTypes");
            DropTable("dbo.Questions");
            DropTable("dbo.Options");
        }
    }
}
