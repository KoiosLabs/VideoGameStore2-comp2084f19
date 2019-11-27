using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using VideoGameStore2.Controllers;
using Xunit;
using System.Linq;
using VideoGameStore2.Models;

namespace VideoGameStoreTests2
{
    public class ShoppingCartTests
    {
        [Fact]
        public void TestAddGameToCart()
        {
            //Arrange 
            var db = MockDb.CreateMockDb();
            CartController cc = new CartController(db);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "Justin"),
                    new Claim(ClaimTypes.NameIdentifier, "test@test.com"),
                }, "mock"));
            cc.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            //Act

            var r = cc.AddToCart(1);

            //Assert
            var result = Assert.IsType<PartialViewResult>(r);
            Assert.NotNull(db.Users.First().CartId);
            Assert.Equal(1, db.CartItems.Count());
        }

        [Fact]
        public void testTotalCartValueWhenCartIsEmpty()
        {
            //Arrange
            ShoppingCart shoppingCart = new ShoppingCart();

            //Act

            //Assert
            Assert.Equal(0, shoppingCart.total);
        }
        [Fact]
        public void testTotalCartValueWhenCartHasItems()
        {
            //Arrange
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.addItem(1);
            //Act

            //Assert
            Assert.Equal(100, shoppingCart.total);
        }
    }
}
