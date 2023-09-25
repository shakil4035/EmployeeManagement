namespace Pims.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateOrganization : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Organizations", "Address");
        }
    }
}
