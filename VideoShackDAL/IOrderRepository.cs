using System;
using System.Collections.Generic;
using System.Text;
using VideoShackDAL.Entities;

namespace VideoShackDAL
{
    public interface IOrderRepository
    {

        Order Create(Order order);

        Order RetrieveOrder(int id);
        List<Order> RetrieveAllOrders();

        Order DeleteOrder(int id);
    }
}
