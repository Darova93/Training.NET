namespace DataAccessEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDateQuestionOption : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Options", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Questions", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "CreateDate");
            DropColumn("dbo.Options", "CreateDate");
        }
    }
}
