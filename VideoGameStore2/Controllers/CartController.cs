using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoGameStore2.Models;

namespace VideoGameStore2.Controllers
{
    public class CartController : Controller
    {

        private readonly GameStoreDBContext _context;

        public CartController(GameStoreDBContext context)
        {
            _context = context;
        }
        public IActionResult AddToCart(int id)
        {
            String userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var gameStoreUser = _context.Users.Where(x => x.Id == userId).SingleOrDefault();

            if(gameStoreUser.cart == null)
            {
                gameStoreUser.cart = new Cart()
                {
                    items = new List<CartItem>()
                };
                _context.Carts.Add(gameStoreUser.cart);
                _context.Update(gameStoreUser);

                 _context.SaveChanges();
                _context.Update(gameStoreUser);
            }

            List<CartItem> items = gameStoreUser.cart.items;
            if (items.Exists(x=> x.GameId == id))
            {
                items.Where(x => x.GameId == id).SingleOrDefault().Qty++;
            }
            else
            {
                CartItem ci = new CartItem()
                {
                    GameId = id,
                    CartId = gameStoreUser.cart.id,
                    Qty= 1
                };
                //_context.Add(ci);
                items.Add(ci);
            }
            _context.Update(gameStoreUser.cart);
            _context.SaveChanges();
            return View();
        }
    }
}