using System;
using System.Collections.Generic;
using System.Text;
using VideoShackBLL.BusinessObjects;
using VideoShackDAL.Entities;

namespace VideoShackBLL.Converters
{
    class OrderConverter
    {
        internal Order Convert(OrderBO order)
        {
            return new Order()
            {
                OrderId = order.OrderId,
                DeliveryDate = order.DeliveryDate,
                OrderDate = order.OrderDate
            };
        }

        internal OrderBO Convert(Order order)
        {
            return new OrderBO()
            {
                OrderId = order.OrderId,
                DeliveryDate = order.DeliveryDate,
                OrderDate = order.OrderDate
            };
        }
    }
}
