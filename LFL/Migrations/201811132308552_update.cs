namespace LFL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseContents",
                c => new
                    {
                        ContentID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.ContentID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseContents", "CourseID", "dbo.Courses");
            DropIndex("dbo.CourseContents", new[] { "CourseID" });
            DropTable("dbo.CourseContents");
        }
    }
}
