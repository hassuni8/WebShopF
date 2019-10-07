using System;
using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SQL
{
    public class FruitContext: DbContext
    {
        public FruitContext(DbContextOptions opt): base(opt)
        {
        }
        
        
        
        
        public DbSet<Fruit> Fruits { get; set; }
    }
}
