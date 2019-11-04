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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .HasMany(Co => Co.Orders)
                .WithOne(o => o.Customer)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(co => co.Orders)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Order>().HasMany(o => o.fruitsInOrder);

        }




        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        
        public DbSet<User> Users { get; set; }
    }
}
