namespace TeisterMask.Models
{
    using Microsoft.EntityFrameworkCore;

    public class TeisterMaskDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        public TeisterMaskDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=CSharp_TeisterMask;user=root;");
        }
    }
}
