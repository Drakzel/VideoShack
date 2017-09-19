using System;

namespace VideoShackDAL.Entites
{
    public class Movie
    {
        public override string ToString(){ return
            $"\nName: {Name}\nGenre: {Genre}\nId: {Id}\n";
        }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Id { get; set; }
    }
}
