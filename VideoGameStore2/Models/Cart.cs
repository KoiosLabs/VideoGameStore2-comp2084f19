using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameStore2.Models
{
    public class Cart
    {
        public virtual int id { get; set; }



        public virtual List<CartItem> items { get; set; }
    }
}
