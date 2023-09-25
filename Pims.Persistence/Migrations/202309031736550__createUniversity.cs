namespace Pims.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _createUniversity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Universities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Universities");
        }
    }
}
