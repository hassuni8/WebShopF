using System;
using System.Collections.Generic;
using Core.Entity;

namespace Infrastructure.SQL
{
    public class DBInitializer
    {
        public static void Initialize(FruitContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            Fruit fruit1 = new Fruit
            {

                Price = 275.0,
                Name = "test",
                Id = 1,
                // allergens = new List<string>(),
                Amount = 7,
                Contents = "test2",
                imgUrl = "test3"

            };

            Fruit fruit2 = new Fruit
            {

                Price = 275.0,
                Name = "test",
                Id = 2,
                // allergens = new List<string>(),
                Amount = 7,
                Contents = "test2",
                imgUrl = "test3"

            };

            Order order1 = new Order
            {

                Id = 3,
                DeliveryDate = DateTime.Now,
                OrderDate = DateTime.Now
                
               

            };

            fruit1 = ctx.Add(fruit1).Entity;
            fruit2 = ctx.Add(fruit2).Entity;
            order1 = ctx.Add(order1).Entity;

            ctx.SaveChanges();
        }
    }
}
