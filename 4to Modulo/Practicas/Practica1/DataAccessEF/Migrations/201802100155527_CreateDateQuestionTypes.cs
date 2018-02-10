namespace DataAccessEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDateQuestionTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuestionTypes", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuestionTypes", "CreateDate");
        }
    }
}
