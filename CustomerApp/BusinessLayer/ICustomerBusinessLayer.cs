using CustomerApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.BusinessLayer
{
    public interface ICustomerBusinessLayer
    {
         List<Customer> GetCustomers();
        void UpdateCustomer(int i, Customer customer);
        int AddCustomer(Customer customer);
        Customer DeleteCustomer(int id);
    }
}
