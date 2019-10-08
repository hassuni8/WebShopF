using System;
using System.Collections.Generic;
using System.Text;
using Core.DomainServices;
using Core.Entity;

namespace Core.ApplicationServices.Services
{
   public class CustomerService: ICustomerService
    {
        private ICustomerRepo _customerRepo;

        public CustomerService(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public Customer NewCustomer(string firstName, string lastName, string address)
        {
            var cus = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address

            };
            return cus;
        }

        public Customer CreateCustomer(Customer cust)
        {
            return _customerRepo.Create(cust);
        }

        public Customer FindCustomerById(int id)
        {
            return _customerRepo.ReadyById(id);
        }

        public Customer FindCustomerByIdIncludeOrders(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepo.ReadAll();
        }

        public int Count()
        {
            return _customerRepo.Count();
        }

        public Customer UpdateCustomer(Customer customerUpdate)
        {
            return _customerRepo.Update(customerUpdate);
        }

        public Customer DeleteCustomer(int id)
        {
            return _customerRepo.Delete(id);
        }
    }
}
