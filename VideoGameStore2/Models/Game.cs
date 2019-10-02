using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VideoGameStore2.Data;

namespace VideoGameStore2.Models
{
    public class Game
    {
        public virtual int Id { get; set; }


        public virtual String Name { get; set; }
        [MaxWords(2, ErrorMessage="You have too many words in {0}")]
        public virtual String Description { get; set; }
        public virtual String MinimumRequirements { get; set; }
        [DataType(DataType.Currency)]

        public virtual Decimal Price { get; set; }

        public virtual String ImageUrl { get; set; }

        public virtual int DeveloperId { get; set; }
        public virtual Developer Dev { get; set; }

        public virtual int GenreId { get; set; }
        public virtual Genre GameGenre { get; set; }
    }
}
