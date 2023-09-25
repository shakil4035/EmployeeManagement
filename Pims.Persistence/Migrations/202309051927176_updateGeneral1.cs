namespace Pims.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateGeneral1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GenarelInformations", "NationalId", c => c.Int(nullable: false));
            AlterColumn("dbo.GenarelInformations", "Nationality", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GenarelInformations", "Nationality", c => c.Int(nullable: false));
            DropColumn("dbo.GenarelInformations", "NationalId");
        }
    }
}
