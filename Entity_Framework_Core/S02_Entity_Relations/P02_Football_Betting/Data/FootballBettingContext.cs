namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FootballBettingContext : DbContext
    {

        public FootballBettingContext()
        {

        }


        public FootballBettingContext(DbContextOptions options)
            : base(options)
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





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=SGEORGIEV\\SQLEXPRESS;Database=FootballBookmakerSystem;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<PlayerStatistic>().HasKey(ps => new
            {
                ps.GameId,
                ps.PlayerId
            });

            modelBuilder.Entity<Team>()
                .HasOne(t => t.SecondaryKitColor)
                .WithMany(t => t.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Teams_Colors_SecondaryKitColorId");

            modelBuilder.Entity<Game>()
                .HasOne(g => g.HomeTeam)
                .WithMany(g => g.HomeGames)
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Games_Teams_HomeTeamId");

            modelBuilder.Entity<PlayerStatistic>()
                .HasOne(ps => ps.Player)
                .WithMany(ps => ps.PlayerStatistics)
                .HasForeignKey(ps => ps.PlayerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_playerStatistics_Players_PlayerId");

        }


        

    }
}
