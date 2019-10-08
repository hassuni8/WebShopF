using System;
using System.Collections.Generic;
using System.Linq;
using Core.DomainServices;
using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SQL.Repositories
{
    public class FruitRepos : IFruitRepo
    {
        private FruitContext _fruitContext;

        public FruitRepos(FruitContext ctx)
        {
            _fruitContext = ctx;
        }
        public Fruit CreateFruit(Fruit fruit)
        {
            if (fruit != null)
            {
                _fruitContext.Attach(fruit).State = EntityState.Added;
            }
            var fruitSaved = _fruitContext.Fruits.Add(fruit).Entity;
            _fruitContext.SaveChanges();
            return fruitSaved;
        }

        public Fruit DeleteFruit(int id)
        {
            var entityRemoved = _fruitContext.Remove(new Fruit { Id = id }).Entity;
            _fruitContext.SaveChanges();
            return entityRemoved;
        }

        public Fruit UpdateFruit(Fruit fruitToUpdate)
        {
            if (fruitToUpdate != null)
            {
                _fruitContext.Attach(fruitToUpdate).State = EntityState.Modified;
            }
            _fruitContext.SaveChanges();
            return fruitToUpdate;
        }

        public Fruit ReadFruit(int id)
        {
            return _fruitContext.Fruits
                .FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Fruit> GetFruit()
        {
            return _fruitContext.Fruits;
                
        }
    }
}
