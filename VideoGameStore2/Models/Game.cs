using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VideoGameStore2.Validators;

namespace VideoGameStore2.Models
{
    public class Game
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual String Name { get; set; }
        [MaxWords(4)]
        public virtual String Description { get; set; }
        public virtual String MinimumRequirements { get; set; }
        [DataType(DataType.Currency)]
        [Required]

        public virtual Decimal Price { get; set; }

        public virtual String ImageUrl { get; set; }

        public virtual int DeveloperId { get; set; }
        public virtual Developer Dev { get; set; }

        public virtual int GenreId { get; set; }
        public virtual Genre GameGenre { get; set; }
    }
}
