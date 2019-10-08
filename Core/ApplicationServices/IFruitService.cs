using System;
using System.Collections.Generic;
using Core.Entity;

namespace Core.ApplicationServices
{
    public interface IFruitService
    {
        Fruit CreateFruit(Fruit fruit);
        Fruit ReadFruit(int id);
        Fruit UpdateFruit(Fruit fruitToUpdate);
        Fruit DeleteFruit(int id);
        List<Fruit> GetFruit();
    }
}
