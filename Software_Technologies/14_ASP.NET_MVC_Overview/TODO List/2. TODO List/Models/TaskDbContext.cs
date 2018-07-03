using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODO_List.Models
{
    public class TaskDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        public TaskDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=todo;user=root;SslMode=none;");
        }
    }
}
