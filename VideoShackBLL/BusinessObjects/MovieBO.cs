using System;
using System.ComponentModel.DataAnnotations;

namespace VideoShackBLL.BusinessObjects
{
    public class MovieBO
    {
        public override string ToString(){ return
            $"\nName: {Name}\nGenre: {Genre}\nId: {Id}\n";
        }

        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string Name { get; set; }

        public string Genre { get; set; }

        public int Id { get; set; }
        
    }
}
