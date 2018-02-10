namespace DataAccessEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedDateQuestionOptions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Options", "ModifiedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Questions", "ModifiedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "ModifiedDate");
            DropColumn("dbo.Options", "ModifiedDate");
        }
    }
}
