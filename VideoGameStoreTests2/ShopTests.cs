using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VideoGameStore2.Controllers;
using VideoGameStore2.Models;
using Xunit;

namespace VideoGameStoreTests2
{

    public class ShopTests
    {


        [Fact]
        public async void IndexTest()
        {
            //Arrange
            var dbContext = MockDb.CreateMockDb();
            ShopController sc = new ShopController(dbContext);
            //Act
            var r = await sc.Index();
            //Assert
            var result = Assert.IsType<ViewResult>(r);
            var model = Assert.IsAssignableFrom<List<Game>>(result.ViewData.Model);
            Assert.Equal(1, model.Count());
        }
    }
}
