using System;
using System.Collections.Generic;
using System.Text;

namespace VideoShackDAL.Entities
{
    public class Collection
    {
        public override string ToString()
        {
            return $"\nCollection Id: {CollectionId}\nCollection Name: {Name}\nMovies: {Movies}\n";
        }
        public int CollectionId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
