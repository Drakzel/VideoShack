using System;
using System.Collections.Generic;
using System.Text;
using VideoShackDAL.Entities;

namespace VideoShackDAL
{
    public interface ICollectionRepository
    {

        Collection Create(Collection collection);

        Collection RetrieveCollection(int id);
        List<Collection> RetrieveAllCollections();

        Collection DeleteCollection(int id);
    }
}
