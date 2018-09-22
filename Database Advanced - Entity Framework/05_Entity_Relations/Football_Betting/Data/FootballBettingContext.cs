using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions options)
        {
        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bet>(entity =>
            {
                entity.HasKey(e => e.BetId);
                entity.HasOne(e => e.Game).WithMany(e => e.Bets)
                    .HasForeignKey(e => e.GameId);
                entity.HasOne(e => e.User).WithMany(e => e.Bets)
                    .HasForeignKey(e => e.UserId);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.ColorId);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryId);
                entity.Property(e => e.Name).HasMaxLength(80).IsRequired();
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.GameId);
                entity.HasOne(e => e.HomeTeam).WithMany(e => e.HomeGames)
                    .HasForeignKey(e => e.HomeTeamId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.AwayTeam).WithMany(e => e.AwayGames)
                    .HasForeignKey(e => e.AwayTeamId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.PlayerId);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(80);
                entity.Property(e => e.IsInjured).HasDefaultValue(false);
                entity.HasOne(e => e.Team).WithMany(e => e.Players)
                    .HasForeignKey(e => e.TeamId);
                entity.HasOne(e => e.Position).WithMany(e => e.Players)
                    .HasForeignKey(e => e.PositionId);
            });

            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(ps => new { ps.PlayerId, ps.GameId });
                entity.HasOne(e => e.Game).WithMany(e => e.PlayerStatistics)
                    .HasForeignKey(e => e.GameId);
                entity.HasOne(e => e.Player).WithMany(e => e.PlayerStatistics)
                    .HasForeignKey(e => e.PlayerId);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.PositionId);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(40);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TeamId);
                entity.Property(e => e.Name).HasMaxLength(80).IsUnicode();
                entity.Property(e => e.Initials).HasColumnType("NCHAR(3)").IsRequired();
                entity.Property(e => e.LogoUrl).IsUnicode(false);
                entity.HasOne(e => e.PrimaryKitColor).WithMany(e => e.PrimaryKitTeams)
                    .HasForeignKey(e => e.PrimaryKitColorId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.SecondaryKitColor).WithMany(e => e.SecondaryKitTeams)
                    .HasForeignKey(e => e.SecondaryKitColorId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Town).WithMany(e => e.Teams)
                    .HasForeignKey(e => e.TownId);
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.HasKey(e => e.TownId);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(80);
                entity.HasOne(e => e.Country).WithMany(e => e.Towns)
                    .HasForeignKey(e => e.CountryId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.Name).HasMaxLength(80);
                entity.Property(e => e.Username).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Password).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(80).IsRequired();
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
