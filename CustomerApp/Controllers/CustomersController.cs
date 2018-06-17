using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CustomerApp.BusinessLayer;
using CustomerApp.Data;

namespace CustomerApp.Controllers
{
    public class CustomersController : ApiController
    {
        private capgeminiEntities db = new capgeminiEntities();
        private ICustomerBusinessLayer _customerBusinessLayer;
        public CustomersController(ICustomerBusinessLayer customerBusinessLayer)
        {
            _customerBusinessLayer = customerBusinessLayer;
        }

        // GET: api/Customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _customerBusinessLayer.GetCustomers();
            //return db.Customers;
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.ID)
            {
                return BadRequest();
            }

           // db.Entry(customer).State = EntityState.Modified;

            try
            {
                //db.SaveChanges();
                _customerBusinessLayer.UpdateCustomer(id, customer);
            }
            catch 
            {
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int id = _customerBusinessLayer.AddCustomer(customer);

            return CreatedAtRoute("DefaultApi", new { id = customer.ID }, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            ////Customer customer = db.Customers.Find(id);
            //if (customer == null)
            //{
            //    return NotFound();
            //}

            Customer customer =_customerBusinessLayer.DeleteCustomer(id);

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }  
    }
}