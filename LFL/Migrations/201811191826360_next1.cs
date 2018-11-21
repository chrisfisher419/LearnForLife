namespace LFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class next1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Replies", "CreateDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Replies", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
