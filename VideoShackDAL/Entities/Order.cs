using System;
using System.Collections.Generic;
using System.Text;

namespace VideoShackDAL.Entities
{
    public class Order
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
