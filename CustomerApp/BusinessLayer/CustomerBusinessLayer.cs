using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomerApp.Data;
using CustomerApp.DataAccessLayer;

namespace CustomerApp.BusinessLayer
{
    public class CustomerBusinessLayer : ICustomerBusinessLayer
    {
        private ICustomerDataAccessLayer _customerBusinessLayer;

     
        public List<Customer> GetCustomers()
        {
            return _customerBusinessLayer.GetCustomers();
        }
        
        public CustomerBusinessLayer(ICustomerDataAccessLayer customerBusinessLayer)
        {
            _customerBusinessLayer = customerBusinessLayer;
        }

        public void UpdateCustomer(int i, Customer customer)
        {
            _customerBusinessLayer.UpdateCustomer(i, customer);
        }

        public int AddCustomer(Customer customer)
        {
            return _customerBusinessLayer.AddCustomer(customer);
        }

        public Customer DeleteCustomer(int id)
        {
           return _customerBusinessLayer.DeleteCustomer(id);
        }
    }
}