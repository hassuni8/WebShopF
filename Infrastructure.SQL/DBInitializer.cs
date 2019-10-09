using System;
using System.Collections.Generic;
using Core.Entity;

namespace Infrastructure.SQL
{
    public class DBInitializer
    {
        public static void Initialize(FruitContext ctx)
        {
            
            ctx.Database.EnsureCreated();

            Fruit fruit1 = new Fruit
            {

                Price = 275.0,
                Name = "test",
                
                // allergens = new List<string>(),
                Amount = 7,
                Contents = "test2",
                imgUrl = "test3"

            };

            Fruit fruit2 = new Fruit
            {

                Price = 275.0,
                Name = "test",
                
                // allergens = new List<string>(),
                Amount = 7,
                Contents = "test2",
                imgUrl = "test3"

            };

            Order order1 = new Order
            {

                
                DeliveryDate = DateTime.Now,
                OrderDate = DateTime.Now
                
               

            };

            Customer cus1 = new Customer
            {
                FirstName = "Per",
                LastName =  "Person",
                Address = "nej gade",
                Orders = new List<Order>()
                
            };

            cus1.Orders.Add(order1);

            

            fruit1 = ctx.Add(fruit1).Entity;
            fruit2 = ctx.Add(fruit2).Entity;
            order1 = ctx.Add(order1).Entity;
            cus1 = ctx.Add(cus1).Entity;

            ctx.SaveChanges();
        }
    }
}
