using System;
using System.Collections.Generic;
using System.Linq;
using Core.DomainServices;
using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SQL.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private FruitContext _fruitContext;

        public OrderRepo(FruitContext ctx)
        {
            _fruitContext = ctx;
        }

        public Order CreateOrder(Order order)
        {
            if (order != null)
            {
                _fruitContext.Attach(order).State = EntityState.Added;
            }
            var orderSaved = _fruitContext.Orders.Add(order).Entity;
            _fruitContext.SaveChanges();
            return orderSaved;
        }

        public Order DeleteOrder(int id)
        {
            var entityRemoved = _fruitContext.Remove(new Order { Id = id }).Entity;
            _fruitContext.SaveChanges();
            return entityRemoved;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _fruitContext.Orders;
        }

        public Order ReadById(int id)
        {
            return _fruitContext.Orders
                .FirstOrDefault(o => o.Id == id);
        }

        public Order UpdateOrder(Order OrderToUpdate)
        {
            if (OrderToUpdate != null)
            {
                _fruitContext.Attach(OrderToUpdate).State = EntityState.Modified;
            }
            _fruitContext.SaveChanges();
            return OrderToUpdate;
        }
    }
}
