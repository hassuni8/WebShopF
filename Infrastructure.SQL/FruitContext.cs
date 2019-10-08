using System;
using System.Collections.Generic;
using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SQL
{
    public class FruitContext : DbContext
    {
        public FruitContext(DbContextOptions opt): base(opt)
        {
        }
        
        
        
        
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
