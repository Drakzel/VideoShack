using System;
using System.Collections.Generic;
using System.Text;
using VideoShackBLL.BusinessObjects;
using VideoShackDAL.Entities;

namespace VideoShackBLL.Converters
{
    class CollectionConverter
    {
        internal Collection Convert(CollectionBO collection)
        {
            return new Collection()
            {
                CollectionId = collection.CollectionId
            };
        }

        internal CollectionBO Convert(Collection collection)
        {
            return new CollectionBO()
            {
                CollectionId = collection.CollectionId
            };
        }
    }
}
