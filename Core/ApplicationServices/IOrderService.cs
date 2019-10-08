using System;
using System.Collections.Generic;
using Core.Entity;

namespace Core.ApplicationServices
{
    public interface IOrderService
    {
        Order New();
        Order CreateOrder(Order order);
        Order FindOrderById(int id);
        List<Order> GetAll();
        Order UpdateOrder(Order OrderToUpdate);
        Order DeleteOrder(int id);


    }
}
