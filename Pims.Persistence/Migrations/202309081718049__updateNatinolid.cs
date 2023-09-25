namespace Pims.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _updateNatinolid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GenarelInformations", "NationalId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GenarelInformations", "NationalId", c => c.Int(nullable: false));
        }
    }
}
