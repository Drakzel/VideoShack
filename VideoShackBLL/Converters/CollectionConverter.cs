using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoShackBLL.BusinessObjects;
using VideoShackDAL.Entities;

namespace VideoShackBLL.Converters
{
    class CollectionConverter
    {
        internal Collection Convert(CollectionBO collection)
        {
            if (collection == null) { return null; }
            return new Collection()
            {
                CollectionId = collection.CollectionId,
                CreatedDate = collection.CreatedDate,
                Name = collection.Name,
                Movies = collection.Movies.ConvertAll(x => new Movie { Id = x.Id, Genre = x.Genre, Name = x.Name })
            };
        }

        internal CollectionBO Convert(Collection collection)
        {
            if (collection == null) { return null; }
            return new CollectionBO()
            {
                CollectionId = collection.CollectionId,
                CreatedDate = collection.CreatedDate,
                Name = collection.Name,
                Movies = collection.Movies.ConvertAll(x => new MovieBO { Id = x.Id, Genre = x.Genre, Name = x.Name})
            };
        }
    }
}
