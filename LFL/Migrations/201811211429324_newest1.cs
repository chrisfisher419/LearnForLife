namespace LFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newest1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessons", "LessonName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lessons", "LessonName");
        }
    }
}
