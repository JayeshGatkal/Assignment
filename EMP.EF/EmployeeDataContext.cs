using EMP.BusinessEntity;
using System.Data.Entity;

namespace EMP.EF
{
    public class EmployeeDataContext : DbContext
    {
        public EmployeeDataContext() : base("EmployeeDbConnection")
        { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<MaritalStatus> MarialStatus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
        }
    }
}
