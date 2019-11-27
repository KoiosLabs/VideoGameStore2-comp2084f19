using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VideoGameStore2.Models;

namespace VideoGameStoreTests2
{
    public static class EntityExtensions
    {
        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
    }
    public class MockDb
    {
        public static GameStoreDBContext CreateMockDb()
        {
            var options = new DbContextOptionsBuilder<GameStoreDBContext>().
                UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var context = new GameStoreDBContext(options))
            {
                context.Users.Add(new GameStoreUser { Email = "test@test.com", Id = "test@test.com" });
                context.Developer.Add(new Developer { Name = "Dev 1", City = "Toronto", DeveloperId = 1, StreetAddress = "123 Yonge", Telephone = "4164164164" });
                context.Genre.Add(new Genre { Name = "Genre", Description = "Desc", GenreId = 1 });
                context.Game.Add(new Game { Id = 1, Name = "Game 1", Description = "Desc 1", DeveloperId = 1, GenreId = 1, ImageUrl = "", MinimumRequirements = "REQ", Price = 20.0m });
                context.SaveChanges();
            }
            return new GameStoreDBContext(options);
        }
    }
}
