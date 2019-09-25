using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameStore2.Models
{
    public class GameStoreUser : IdentityUser
    {
        public virtual String FavouriteGame { get; set; }
    }
}
