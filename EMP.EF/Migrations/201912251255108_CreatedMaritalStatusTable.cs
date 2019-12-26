namespace EMP.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedMaritalStatusTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaritalStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MaritalStatus");
        }
    }
}
