using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace VideoGameStore2.Models
{
    public class ShoppingCart
    {
        private GameStoreDBContext _context;
        private ClaimsPrincipal User;
        private String userId
        {
            get
            {
                return User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }
        public decimal total { get
            {
                var dbUser = _context.Users.Include(user => user.Cart).Include(user => user.Cart.CartItems).Include("Cart.CartItems.game").Where(x => x.Id == userId).SingleOrDefault();
                return dbUser.Cart?.CartItems?.Sum(x => x.game.Price * x.Qty) ?? 0.0m;
                //return 0;
            } 
        }

        public ShoppingCart(GameStoreDBContext db,ClaimsPrincipal User)
        {
            this._context = db;
            this.User = User;
        }

        public bool addItem(int id)
        {
            var gameStoreUser = _context.Users.Include(user => user.Cart).Include(user => user.Cart.CartItems)
                .Where(x => x.Id == userId).SingleOrDefault();

            if (gameStoreUser.Cart == null)
            {
                gameStoreUser.Cart = new Cart()
                {
                    CartItems = new List<CartItem>()
                };
                _context.Carts.Add(gameStoreUser.Cart);
                _context.Update(gameStoreUser);

                _context.SaveChanges();
                _context.Update(gameStoreUser);
            }

            List<CartItem> items = gameStoreUser.Cart.CartItems;
            if (items.Exists(x => x.GameId == id))
            {
                items.Where(x => x.GameId == id).SingleOrDefault().Qty++;
            }
            else
            {
                CartItem ci = new CartItem()
                {
                    GameId = id,
                    CartId = gameStoreUser.Cart.Id,
                    Qty = 1
                };
                //_context.Add(ci);
                items.Add(ci);
            }
            _context.Update(gameStoreUser.Cart);
            _context.SaveChanges();
            return true;
        }

    }
}
