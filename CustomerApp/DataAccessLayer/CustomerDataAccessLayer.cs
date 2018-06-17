using CustomerApp.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomerApp.DataAccessLayer
{
    public class CustomerDataAccessLayer : ICustomerDataAccessLayer
    {
        
        public List<Customer> GetCustomers()
        {
            using (var db = new capgeminiEntities())
            {
                return db.Customers.ToList();
            }
        }

        public void UpdateCustomer(int i, Customer customer)
        {
            using (var db = new capgeminiEntities())
            {

                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int AddCustomer(Customer customer)
        {
            using (var db = new capgeminiEntities())
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return customer.ID;
            }
        }

        public Customer DeleteCustomer(int id)
        {
            using (var db = new capgeminiEntities())
            {
                var customerDb = db.Customers.Find(id);
                db.Customers.Remove(customerDb);
                db.SaveChanges();
                return customerDb;
            }
        }
    }
}