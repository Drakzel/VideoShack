using System;
using System.Collections.Generic;
using System.Text;
using VideoShackBLL.BusinessObjects;

namespace VideoShackBLL
{
    public interface ICollectionService
    {
        //c
        CollectionBO Create(CollectionBO collection);
        //r
        List<CollectionBO> RetrieveAllCollections();
        CollectionBO RetrieveCollection(int id);
        //u
        CollectionBO Update(CollectionBO collection);
        //d
        CollectionBO Delete(int id);
    }
}
