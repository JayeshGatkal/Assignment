namespace EMP.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMaritalStatusIdToEmployeeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "MaritalStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "MaritalStatusId");
            AddForeignKey("dbo.Employees", "MaritalStatusId", "dbo.MaritalStatus", "Id", cascadeDelete: true);
            DropColumn("dbo.Employees", "MaritalStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "MaritalStatus", c => c.String(maxLength: 10));
            DropForeignKey("dbo.Employees", "MaritalStatusId", "dbo.MaritalStatus");
            DropIndex("dbo.Employees", new[] { "MaritalStatusId" });
            DropColumn("dbo.Employees", "MaritalStatusId");
        }
    }
}
