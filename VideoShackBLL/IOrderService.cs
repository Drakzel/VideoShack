using System;
using System.Collections.Generic;
using System.Text;
using VideoShackBLL.BusinessObjects;

namespace VideoShackBLL
{
    public interface IOrderService
    {
        //c
        OrderBO Create(OrderBO order);
        //r
        List<OrderBO> RetrieveAllOrders();
        OrderBO RetrieveOrder(int id);
        //u
        OrderBO Update(OrderBO order);
        //d
        OrderBO Delete(int id);
    }
}
