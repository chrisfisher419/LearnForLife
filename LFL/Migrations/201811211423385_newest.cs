namespace LFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "CourseID", "dbo.Courses");
            DropIndex("dbo.Questions", new[] { "CourseID" });
            RenameColumn(table: "dbo.Questions", name: "CourseID", newName: "Course_CourseID");
            AddColumn("dbo.Questions", "LessonID", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "Course_CourseID", c => c.Int());
            CreateIndex("dbo.Questions", "LessonID");
            CreateIndex("dbo.Questions", "Course_CourseID");
            AddForeignKey("dbo.Questions", "LessonID", "dbo.Lessons", "LessonID", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "Course_CourseID", "dbo.Courses", "CourseID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.Questions", "LessonID", "dbo.Lessons");
            DropIndex("dbo.Questions", new[] { "Course_CourseID" });
            DropIndex("dbo.Questions", new[] { "LessonID" });
            AlterColumn("dbo.Questions", "Course_CourseID", c => c.Int(nullable: false));
            DropColumn("dbo.Questions", "LessonID");
            RenameColumn(table: "dbo.Questions", name: "Course_CourseID", newName: "CourseID");
            CreateIndex("dbo.Questions", "CourseID");
            AddForeignKey("dbo.Questions", "CourseID", "dbo.Courses", "CourseID", cascadeDelete: true);
        }
    }
}
