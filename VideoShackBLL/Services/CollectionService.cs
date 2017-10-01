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

        public CollectionBO Create(CollectionBO order)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newOrder = uow.CollectionRepository.Create(conv.Convert(order));
                uow.Complete();
                return conv.Convert(newOrder);
            }
        }

        public CollectionBO Delete(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var OrderToDelete = uow.CollectionRepository.DeleteCollection(id);
                uow.Complete();
                return conv.Convert(OrderToDelete);
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
                var RetrievedOrder = uow.CollectionRepository.RetrieveCollection(id);
                return conv.Convert(RetrievedOrder);
            }
        }

        public CollectionBO Update(CollectionBO collection)
        {
            using (var uow = facade.UnitOfWork)
            {
                var OrderToUpdate = uow.CollectionRepository.RetrieveCollection(collection.CollectionId);
                if (OrderToUpdate == null)
                {
                    throw new InvalidOperationException("Order not found.");
                }
                //OrderToUpdate.Movies = order.Movies, ?????
                uow.Complete();
                return conv.Convert(OrderToUpdate);
            }
        }
    }
}
