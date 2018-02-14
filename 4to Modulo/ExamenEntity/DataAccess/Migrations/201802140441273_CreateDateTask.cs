namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDateTask : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "CreateDate");
        }
    }
}
