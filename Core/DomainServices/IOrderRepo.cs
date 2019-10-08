using System;
using System.Collections.Generic;
using Core.Entity;

namespace Core.DomainServices
{
    public interface IOrderRepo
    {
        Order CreateOrder(Order order);
        Order ReadById(int id);
        IEnumerable<Order> GetOrders();
        Order UpdateOrder(Order OrderToUpdate);
        Order DeleteOrder(int id);

    }
}
