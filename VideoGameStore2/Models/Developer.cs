using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoGameStore2.Models
{
    public class Developer
    {
        [Key]
        public virtual int DeveloperId { get; set; }

        [Display(Name = "Developer Name")]
        [Required]
        public virtual String Name { get; set; }
        [Required]
        public virtual String StreetAddress { get; set; }
        [Required]
        public virtual String City { get; set; }

        [Required]
        public virtual String Telephone { get; set; }

        public virtual List<Game> Games
        {
            get; set;
        }
    }
}
