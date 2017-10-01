using System;
using System.Collections.Generic;
using System.Text;

namespace VideoShackBLL.BusinessObjects
{
    public class CollectionBO
    {
        public override string ToString()
        {
            return $"\nCollectionId: {CollectionId}\nMovies: {Movies}\n";
        }
        public int CollectionId { get; set; }
        public List<MovieBO> Movies { get; set; }
    }
}
