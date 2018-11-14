namespace LFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerID = c.Int(nullable: false, identity: true),
                        QuestionID = c.Int(nullable: false),
                        Answers = c.String(),
                        Correct = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AnswerID)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        Questions = c.String(),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        CourseInfo = c.String(),
                        SubjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.SubjectID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        EnrollmentID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollmentID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.CourseID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.MessageBoards",
                c => new
                    {
                        TopicID = c.Int(nullable: false, identity: true),
                        TopicName = c.String(),
                        UserID = c.Int(nullable: false),
                        UserName = c.String(),
                        TopicSubject = c.String(),
                        TopicMessage = c.String(),
                    })
                .PrimaryKey(t => t.TopicID);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        ReplyID = c.Int(nullable: false, identity: true),
                        TopicID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        UserName = c.String(),
                        ReplyMessage = c.String(),
                    })
                .PrimaryKey(t => t.ReplyID)
                .ForeignKey("dbo.MessageBoards", t => t.TopicID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.TopicID)
                .Index(t => t.UserID);
            
            AddColumn("dbo.AspNetUsers", "User_UserID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "User_UserID");
            AddForeignKey("dbo.AspNetUsers", "User_UserID", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Replies", "UserID", "dbo.Users");
            DropForeignKey("dbo.Replies", "TopicID", "dbo.MessageBoards");
            DropForeignKey("dbo.Enrollments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Enrollments", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Answers", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.Questions", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Courses", "SubjectID", "dbo.Subjects");
            DropIndex("dbo.AspNetUsers", new[] { "User_UserID" });
            DropIndex("dbo.Replies", new[] { "UserID" });
            DropIndex("dbo.Replies", new[] { "TopicID" });
            DropIndex("dbo.Enrollments", new[] { "CourseID" });
            DropIndex("dbo.Enrollments", new[] { "UserID" });
            DropIndex("dbo.Courses", new[] { "SubjectID" });
            DropIndex("dbo.Questions", new[] { "CourseID" });
            DropIndex("dbo.Answers", new[] { "QuestionID" });
            DropColumn("dbo.AspNetUsers", "User_UserID");
            DropTable("dbo.Replies");
            DropTable("dbo.MessageBoards");
            DropTable("dbo.Users");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Subjects");
            DropTable("dbo.Courses");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
