using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainServices;
using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SQL.Repositories
{
    public class CustomerRepo: ICustomerRepo
    {
        private FruitContext _ctx;

        public CustomerRepo(FruitContext ctx)
        {
            _ctx = ctx;
        }

        public Customer Create(Customer customer)
        {
          
           var customerSaved = _ctx.Customers.Add(customer).Entity;
            _ctx.SaveChanges();
            return customerSaved;
        }

        public Customer ReadyById(int id)
        {
            return _ctx.Customers
                .Include(c => c.Id)
                .FirstOrDefault(c => c.Id == id);
        }

        public List<Customer> ReadAll()
        {
            return _ctx.Customers.ToList();
        }

        public int Count()
        {
            return _ctx.Customers.Count();
        }

        public Customer Update(Customer customerUpdate)
        {
            _ctx.Attach(customerUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return customerUpdate;
        }

        public Customer Delete(int id)
        {
            var CusToDelete = _ctx.Remove(new Customer {Id = id}).Entity;
            _ctx.SaveChanges();
            return CusToDelete;
        }

        public Customer ReadyByIdIncludeOrders(int id)
        {
            throw new NotImplementedException();
        }
    }
}
