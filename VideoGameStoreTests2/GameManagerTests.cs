using System;
using System.Collections.Generic;
using System.Text;
using VideoGameStore2.Controllers;
using VideoGameStore2.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VideoGameStoreTests2
{
    public class GameManagerTests
    {

        

        [Fact]
        public async void TestAddGame()
        {
            //Arrange           
            var db = MockDb.CreateMockDb();
            var c = new GameManagerController(db);

            var game = new Game {  Name = "Game 2", Description = "Desc 2", DeveloperId = 1, GenreId = 1, ImageUrl = "", MinimumRequirements = "REQ", Price = 29.99m };
            //Act
            var r = await c.Create(game);
            //Assert
            var result = Assert.IsType<RedirectToActionResult>(r);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal(1, db.Game.Where(x => x.Name == game.Name && x.Description == game.Description && x.DeveloperId == game.DeveloperId).Count()
);
        }

        [Fact]
        public async void TestAddInvalidGame()
        {
            //Arrange
            var db = MockDb.CreateMockDb();
            var c = new GameManagerController(db);

            var game = new Game { Description = "Desc 2", DeveloperId = 1, GenreId = 1, ImageUrl = "", MinimumRequirements = "REQ", Price = 29.99m };
            c.ModelState.AddModelError("Name", "Required");

            //Act

            var r = await c.Create(game);
            //Assert
            var result = Assert.IsType<ViewResult>(r);
            var model = Assert.IsAssignableFrom<Game>(result.ViewData.Model);
            Assert.Equal(game, model);
            Assert.IsType<SelectList>(result.ViewData["DeveloperId"]);
            Assert.IsType<SelectList>(result.ViewData["GenreId"]);
        }
    }
}
