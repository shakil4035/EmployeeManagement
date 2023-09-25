namespace Pims.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class educationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EducationInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenarelInformationId = c.Int(nullable: false),
                        UniversityId = c.Int(nullable: false),
                        ExamName = c.String(),
                        PassingYear = c.DateTime(nullable: false),
                        SubjectName = c.String(),
                        Result = c.Double(nullable: false),
                        SchoolOrCollage = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        CreateBy = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.String(),
                        UpdateDate = c.DateTime(),
                        IsDeleteBy = c.String(),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GenarelInformations", t => t.GenarelInformationId, cascadeDelete: true)
                .ForeignKey("dbo.Universities", t => t.UniversityId, cascadeDelete: true)
                .Index(t => t.GenarelInformationId)
                .Index(t => t.UniversityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EducationInfoes", "UniversityId", "dbo.Universities");
            DropForeignKey("dbo.EducationInfoes", "GenarelInformationId", "dbo.GenarelInformations");
            DropIndex("dbo.EducationInfoes", new[] { "UniversityId" });
            DropIndex("dbo.EducationInfoes", new[] { "GenarelInformationId" });
            DropTable("dbo.EducationInfoes");
        }
    }
}
