namespace DataAccessEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedDateOptional : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Options", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Questions", "ModifiedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "ModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Options", "ModifiedDate", c => c.DateTime(nullable: false));
        }
    }
}
