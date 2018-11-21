namespace LFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class again : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Replies", "ReplyMessage", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Replies", "ReplyMessage", c => c.String());
        }
    }
}
