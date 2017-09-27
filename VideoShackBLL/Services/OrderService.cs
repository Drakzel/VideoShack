using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoShackBLL.BusinessObjects;
using VideoShackBLL.Converters;
using VideoShackDAL;

namespace VideoShackBLL.Services
{
    class OrderService : IOrderService
    {
        DALFacade facade;
        OrderConverter conv = new OrderConverter();

        public OrderService (DALFacade facade)
        {
            this.facade = facade;
        }

        public OrderBO Create(OrderBO order)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newOrder = uow.OrderRepository.Create(conv.Convert(order));
                uow.Complete();
                return conv.Convert(newOrder);
            }
        }

        public OrderBO Delete(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var OrderToDelete = uow.OrderRepository.DeleteOrder(id);
                uow.Complete();
                return conv.Convert(OrderToDelete);
            }
        }

        public List<OrderBO> RetrieveAllOrders()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.OrderRepository.RetrieveAllOrders().Select(conv.Convert).ToList();
            }
        }

        public OrderBO RetrieveOrder(int id)
        {
            using (var uow = facade.UnitOfWork)
            {
                var RetrievedOrder = uow.OrderRepository.RetrieveOrder(id);
                return conv.Convert(RetrievedOrder);
            }
        }

        public OrderBO Update(OrderBO order)
        {
            using (var uow = facade.UnitOfWork)
            {
                var OrderToUpdate = uow.OrderRepository.RetrieveOrder(order.OrderId);
                if (OrderToUpdate == null)
                {
                    throw new InvalidOperationException("Order not found.");
                }
                OrderToUpdate.DeliveryDate = order.DeliveryDate;
                OrderToUpdate.OrderDate = order.OrderDate;
                uow.Complete();
                return conv.Convert(OrderToUpdate);
            }
        }
    }
}
