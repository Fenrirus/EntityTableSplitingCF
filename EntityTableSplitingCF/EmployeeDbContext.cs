using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EntityTableSplitingCF
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(pk => pk.EmployeeID)
                .ToTable("Employees");
            modelBuilder.Entity<EmployeeContacs>()
              .HasKey(pk => pk.EmployeeID)
              .ToTable("Employees");

            modelBuilder.Entity<Employee>()
                .HasRequired(p => p.employeeContacs)
                .WithRequiredPrincipal(c => c.employee);
            base.OnModelCreating(modelBuilder);
        }
    }
}