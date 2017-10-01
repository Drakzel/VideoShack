using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoShackDAL.Context;
using VideoShackDAL.Entities;

namespace VideoShackDAL.Repositories
{
    class CollectionRepository : ICollectionRepository
    {
        VideoShackContext context;

        public CollectionRepository(VideoShackContext context)
        {
            this.context = context;
        }

        public Collection Create(Collection collection)
        {
            context.Collections.Add(collection);
            return collection;
        }

        public Collection DeleteCollection(int id)
        {
            var collection = RetrieveCollection(id);
            context.Collections.Remove(collection);
            return collection;
        }

        public List<Collection> RetrieveAllCollections()
        {
            return context.Collections.ToList();
        }

        public Collection RetrieveCollection(int id)
        {
            return context.Collections.FirstOrDefault(o => o.CollectionId == id);
        }
    }
}
