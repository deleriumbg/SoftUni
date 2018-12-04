using IRunesWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace IRunesWebApp.Data
{
    public class IRunesDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<AlbumTrack> AlbumsTracks { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DELIRIUM\\SQLEXPRESS;Database=IRunes;Integrated Security=True;").UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlbumTrack>().HasKey(at => new {at.AlbumId, at.TrackId});
        }
    }
}
