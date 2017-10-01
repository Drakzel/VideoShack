using System;
using System.Collections.Generic;
using System.Text;

namespace VideoShackDAL.Entities
{
    public class Collection
    {
        public override string ToString()
        {
            return $"\nOrder Id: {CollectionId}\nMovies: {Movies}\n";
        }
        public int CollectionId { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
