using System;
using System.Collections.Generic;

namespace Core.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        //public List<Fruit> ListOFruits { get; set; }
        //public Customer Customer { get; set; }
       
    }
}
