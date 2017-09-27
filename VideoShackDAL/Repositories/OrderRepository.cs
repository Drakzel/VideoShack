using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoShackDAL.Context;
using VideoShackDAL.Entities;

namespace VideoShackDAL.Repositories
{
    class OrderRepository : IOrderRepository
    {
        VideoShackContext context;

        public OrderRepository(VideoShackContext context)
        {
            this.context = context;
        }

        public Order Create(Order order)
        {
            context.Orders.Add(order);
            return order;
        }

        public Order DeleteOrder(int id)
        {
            var order = RetrieveOrder(id);
            context.Orders.Remove(order);
            return order;
        }

        public List<Order> RetrieveAllOrders()
        {
            return context.Orders.ToList();
        }

        public Order RetrieveOrder(int id)
        {
            return context.Orders.FirstOrDefault(o => o.OrderId == id);
        }
    }
}
