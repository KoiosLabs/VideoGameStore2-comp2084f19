using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameStore2.Models
{
    public class CartItem
    {
        public virtual int Id { get; set; }
        public virtual int CartId { get; set; }
        public virtual Cart cart { get; set; }

        public virtual int GameId { get; set; }
        public virtual Game game { get; set; }

        public virtual int Qty { get; set; }
    }
}
