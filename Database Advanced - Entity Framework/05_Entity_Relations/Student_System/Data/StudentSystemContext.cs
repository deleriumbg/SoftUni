using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data 
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);
                entity.Property(e => e.Name).IsUnicode().HasMaxLength(100).IsRequired();
                entity.Property(e => e.PhoneNumber).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.RegisteredOn).IsRequired();
                entity.HasMany(e => e.HomeworkSubmissions).WithOne(e => e.Student).HasForeignKey(e => e.StudentId);
                entity.HasMany(e => e.CourseEnrollments).WithOne(e => e.Student).HasForeignKey(e => e.StudentId);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.CourseId);
                entity.Property(e => e.Name).IsUnicode().HasMaxLength(50).IsRequired();
                entity.Property(e => e.Description).IsUnicode();
                entity.HasMany(e => e.StudentsEnrolled).WithOne(e => e.Course).HasForeignKey(e => e.CourseId);
                entity.HasMany(e => e.HomeworkSubmissions).WithOne(e => e.Course).HasForeignKey(e => e.CourseId);
                entity.HasMany(e => e.Resources).WithOne(e => e.Course).HasForeignKey(e => e.CourseId);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.ResourceId);
                entity.Property(e => e.Name).IsUnicode().HasMaxLength(50).IsRequired();
                entity.Property(e => e.Url).IsUnicode(false);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(e => e.HomeworkId);
                entity.Property(e => e.Content).IsUnicode(false);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(sc => new { sc.StudentId, sc.CourseId });
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }
    }
}
