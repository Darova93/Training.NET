namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDateTag : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tags", "CreateDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tags", "CreateDate");
        }
    }
}
