namespace EMP.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedValidationForEmployeeTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Employees", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Employees", "MaritalStatus", c => c.String(maxLength: 10));
            AlterColumn("dbo.Employees", "Location", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Location", c => c.String());
            AlterColumn("dbo.Employees", "MaritalStatus", c => c.String());
            AlterColumn("dbo.Employees", "LastName", c => c.String());
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
        }
    }
}
