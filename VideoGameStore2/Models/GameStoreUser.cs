using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameStore2.Models
{
    public class GameStoreUser : IdentityUser
    {
        public virtual String FavouriteGame { get; set; }

        public virtual int? CartId { get; set; }
        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; }
    }
}
