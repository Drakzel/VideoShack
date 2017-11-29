using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoShackBLL.BusinessObjects;
using VideoShackBLL.Converters;
using VideoShackDAL;

namespace VideoShackBLL.Services
{
    class CollectionService : ICollectionService
    {
        DALFacade facade;
        CollectionConverter conv = new CollectionConverter();

        public CollectionService (DALFacade facade)
        {
            this.facade = facade;
        }

        public CollectionBO Create(CollectionBO collection)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newCollection = uow.CollectionRepository.Create(conv.Convert(collection));
                uow.Complete();
                return conv.Convert(newCollection);
            }
        }

        public CollectionBO Delete(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var CollectionToDelete = uow.CollectionRepository.DeleteCollection(id);
                uow.Complete();
                return conv.Convert(CollectionToDelete);
            }
        }

        public List<CollectionBO> RetrieveAllCollections()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.CollectionRepository.RetrieveAllCollections().Select(conv.Convert).ToList();
            }
        }

        public CollectionBO RetrieveCollection(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var RetrievedCollection = uow.CollectionRepository.RetrieveCollection(id);
                return conv.Convert(RetrievedCollection);
            }
        }

        public CollectionBO Update(CollectionBO collection)
        {
            using (var uow = facade.UnitOfWork)
            {
                var CollectionFromDB = uow.CollectionRepository.RetrieveCollection(collection.CollectionId);
                if (CollectionFromDB == null)
                {
                    throw new InvalidOperationException("Collection not found.");
                }
                CollectionFromDB.CreatedDate = collection.CreatedDate;
                uow.Complete();
                return conv.Convert(CollectionFromDB);
            }
        }
    }
}
