namespace Pims.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _createGenarelInformation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenarelInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.String(nullable: false),
                        NameBangla = c.String(),
                        NameEnglish = c.String(),
                        FatherName = c.String(),
                        MotherName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        BirthPlace = c.String(),
                        Nationality = c.Int(nullable: false),
                        PresentAddress = c.String(),
                        PermanentAddress = c.String(),
                        BloodGroup = c.String(),
                        Religion = c.String(),
                        Gender = c.String(),
                        MeritialStatus = c.String(),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        Position = c.String(),
                        DesignationId = c.Int(nullable: false),
                        JobJoiningDate = c.DateTime(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        CreateBy = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.String(),
                        UpdateDate = c.DateTime(),
                        IsDeleteBy = c.String(),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.DesignationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GenarelInformations", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.GenarelInformations", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.GenarelInformations", new[] { "DesignationId" });
            DropIndex("dbo.GenarelInformations", new[] { "DepartmentId" });
            DropTable("dbo.GenarelInformations");
        }
    }
}
