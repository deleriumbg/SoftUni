using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.Data
{
    public class EmployeesMappingContext : DbContext
    {
        public EmployeesMappingContext(DbContextOptions options)
            : base(options)
        {
        }

        public EmployeesMappingContext()
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DELIRIUM\\SQLEXPRESS;Database=EmployeesDatabase;Integrated Security=True;");
            }
        }
    }
}
