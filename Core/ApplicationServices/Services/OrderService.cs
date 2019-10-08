using System;
using System.Collections.Generic;
using System.Linq;
using Core.DomainServices;
using Core.Entity;

namespace Core.ApplicationServices.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;

        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public Order CreateOrder(Order order)
        {
            return _orderRepo.CreateOrder(order);
        }

        public Order DeleteOrder(int id)
        {
            return _orderRepo.DeleteOrder(id);
        }

        public Order FindOrderById(int id)
        {
            return _orderRepo.ReadById(id);
        }

        public List<Order> GetAll()
        {
            return _orderRepo.GetOrders().ToList();
        }

        public Order New()
        {
            return new Order();
        }

        public Order UpdateOrder(Order OrderToUpdate)
        {
            return _orderRepo.UpdateOrder(OrderToUpdate);
        }
    }
}
