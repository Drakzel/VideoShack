using System;
using System.Collections.Generic;
using System.Text;

namespace VideoShackBLL.BusinessObjects
{
    public class OrderBO
    {
        public override string ToString()
        {
            return $"\nOrder Id: {OrderId}\nOrder Date: {OrderDate}\nDelivery Date: {DeliveryDate}\n";
        }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
