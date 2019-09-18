using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameStore2.Models
{
    public class Genre
    {

        public Genre() { }
        public Genre(int GenreId, String Name, String Description)
        {
            this.GenreId = GenreId;
            this.Name = Name;
            this.Description = Description;
        }

        [Key]
        public virtual int GenreId { get; set; }


        [Required]
        [Display(Name="Genre Name")]
        public virtual String Name { get; set; }

        [Required]
        public virtual String Description { get; set; }

        public virtual List<Game> Games { get; set; }

    }
}
