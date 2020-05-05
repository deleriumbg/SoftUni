using Microsoft.EntityFrameworkCore;

namespace LogNoziroh.Models
{
    public class LogNozirohDbContext : DbContext
    {
        public DbSet<Report> Reports { get; set; }

        public LogNozirohDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=CSharp_LogNoziroh;user=root;");
        }
    }
}
