using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VideoGameStore2.Models;

namespace VideoGameStore2.Models
{
    public class GameStoreDBContext : DbContext
    {
        public GameStoreDBContext (DbContextOptions<GameStoreDBContext> options)
            : base(options)
        {
        }

        public DbSet<VideoGameStore2.Models.Game> Game { get; set; }

        public DbSet<VideoGameStore2.Models.Genre> Genre { get; set; }

        public DbSet<VideoGameStore2.Models.Developer> Developer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genre>().HasData(
                new Genre(1, "First Person Shooters", "Games where you shoot things with guns"),
                new Genre(2, "Simulation", "Pretending to be real life, but not")
                );

            modelBuilder.Entity<Developer>().HasData(
                new Developer() { DeveloperId = 1, Name = "Konami", City = "Tokyo", StreetAddress = "A road in Japan", Telephone = "123456789" },
                new Developer() { DeveloperId = 2, Name = "Squad", City = "Mexico City", StreetAddress = "Probably poorly defined", Telephone = "0987654321" },
                new Developer() { DeveloperId = 3, Name = "Uber Entertainment", City = "Montreal", StreetAddress = "some french road", Telephone = "83798273489" }
                );

            modelBuilder.Entity<Game>().HasData(
                new Models.Game() { Id = 3, Name = "Metal Gear Solid", Description = "Sneak a lot", MinimumRequirements = "PS4", Price = 59.99M, DeveloperId = 1, GenreId = 1 },
                new Models.Game() { Id = 4, Name = "Kerbal Space Program", Description = "Science the shit out stuff", MinimumRequirements = "A Computer", Price = 6.99M, DeveloperId = 2, GenreId = 2 },
                new Models.Game() { Id = 5, Name = "Kerbal Space Program 2", Description = "Science the shit out stuff, Harder", MinimumRequirements = "A Computer", Price = 69.99M, DeveloperId = 3, GenreId = 2 }
            );
        }
    }
}
