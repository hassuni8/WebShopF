﻿using System;
using System.Collections.Generic;
using Core.Entity;

namespace Core.DomainServices
{
    public interface IFruitRepo
    {
        Fruit CreateFruit(Fruit fruit);
        Fruit DeleteFruit(int id);
        Fruit UpdateFruit(Fruit fruitToUpdate);
        Fruit ReadFruit(int id);
        IEnumerable<Fruit> GetFruit();
    }
}
