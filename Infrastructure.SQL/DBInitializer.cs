using System;
using System.Collections.Generic;
using Core.Entity;

namespace Infrastructure.SQL
{
    public class DBInitializer
    {
        public static void Initialize(FruitContext ctx)
        {

            Fruit fruit1 = new Fruit
            {

                Price = 275.0,
                Name = "test",
                Id = 1,
                allergens = new List<String>(),
                amoung = 7,
                Contents = "test2",
                imgUrl = "test3"

            };
        }
    }
}
