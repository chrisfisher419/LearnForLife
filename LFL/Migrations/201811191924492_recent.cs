namespace LFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        LessonID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.LessonID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "CourseID", "dbo.Courses");
            DropIndex("dbo.Lessons", new[] { "CourseID" });
            DropTable("dbo.Lessons");
        }
    }
}
