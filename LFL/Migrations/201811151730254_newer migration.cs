namespace LFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newermigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "CourseContent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "CourseContent");
        }
    }
}
