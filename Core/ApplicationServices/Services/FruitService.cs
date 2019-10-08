using System;
using System.Collections.Generic;
using System.Linq;
using Core.DomainServices;
using Core.Entity;

namespace Core.ApplicationServices.Services
{
    public class FruitService : IFruitService
    {
        private readonly IFruitRepo _fruitRepo;

        public FruitService(IFruitRepo fruitRepo)
        {
            _fruitRepo = fruitRepo;
        }

        public Fruit CreateFruit(Fruit fruit)
        {
            return _fruitRepo.CreateFruit(fruit);
        }

        public Fruit ReadFruit(int id)
        {
            return _fruitRepo.ReadFruit(id);
        }

        public Fruit UpdateFruit(Fruit fruitToUpdate)
        {
            return _fruitRepo.UpdateFruit(fruitToUpdate);
        }

        public Fruit DeleteFruit(int id)
        {
            return _fruitRepo.DeleteFruit(id);
        }

        public List<Fruit> GetFruit()
        {
            return _fruitRepo.GetFruit().ToList();
        }


    }
}
