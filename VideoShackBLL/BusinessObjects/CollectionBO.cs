using System;
using System.Collections.Generic;
using System.Text;

namespace VideoShackBLL.BusinessObjects
{
    public class CollectionBO
    {
        public override string ToString()
        {
            return $"\nCollection Id: {CollectionId}\nCollection Name: {Name}\nMovies: {Movies}\n";
        }
        public int CollectionId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<MovieBO> Movies { get; set; }
    }
}
