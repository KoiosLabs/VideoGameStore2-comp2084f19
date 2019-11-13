using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using VideoGameStore2.Models;
using Xunit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using VideoGameStore2.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace VideoGameStoreTests
{

    public static class EntityExtensions
    {
        public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            dbSet.RemoveRange(dbSet);
        }
    }
    public class ShopTests
    {
        //private Mock<DbSet<T>> getMockDbSet(IQueryable<T> data)
        //{

        //}

        private GameStoreDBContext MockDb()
        {
            var options = new DbContextOptionsBuilder<GameStoreDBContext>().UseInMemoryDatabase(databaseName: "GameStoreDatabase").Options;
            
            using (var context = new GameStoreDBContext(options))
            {
                context.Developer.Clear();
                context.Genre.Clear();
                context.Game.Clear();
                
                context.Developer.Add(new Developer { Name = "Dev 1", City = "Toronto", DeveloperId = 1, StreetAddress = "123 Yonge", Telephone = "4164164164" });
                context.Genre.Add(new Genre { Name = "Genre", Description = "Desc", GenreId = 1 });
                context.Game.Add(new Game { Id = 1, Name = "Game 1", Description = "Desc 1", DeveloperId = 1, GenreId = 1, ImageUrl = "", MinimumRequirements = "REQ", Price = 19.99m });
                context.SaveChanges();
            }
            return new GameStoreDBContext(options);
        }

        [Fact]
        public async void TestIndex()
        {
            //Arrange
            var context = MockDb();
            ShopController sc = new ShopController(context);

            //act
            var r = await sc.Index();

            //Assert
            var result = Assert.IsType<ViewResult>(r);
            var model = Assert.IsAssignableFrom<List<Game>>(result.ViewData.Model);
            Assert.Equal(1, model.Count());

        }
        [Fact]
        public async void TestAddGame()
        {
            //Arrange
            var context = MockDb();
            GameManagerController sc = new GameManagerController(context);
            var game = new Game { Id = 2, Name = "Game 2", Description = "Desc 2", DeveloperId = 1, GenreId = 1, ImageUrl = "", MinimumRequirements = "REQ", Price = 29.99m };

            //act
            var r = await sc.Create(game);

            //Assert
            var result = Assert.IsType<RedirectToActionResult>(r);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal(2, context.Game.Count());

        }
    }
}
