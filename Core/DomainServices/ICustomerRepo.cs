using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity;

namespace Core.DomainServices
{
    public interface ICustomerRepo
    {
        Customer Create(Customer customer);
        //Read Data
        Customer ReadyById(int id);
        List<Customer> ReadAll();
        int Count();
        //Update Data
        Customer Update(Customer customerUpdate);
        //Delete Data
        Customer Delete(int id);
        Customer ReadyByIdIncludeOrders(int id);
    }
}
