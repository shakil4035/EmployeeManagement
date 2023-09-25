namespace Pims.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSalary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GenarelInformations", "BasicSalary", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GenarelInformations", "BasicSalary");
        }
    }
}
