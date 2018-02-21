using MyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebAPI.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        [Route()]
        [HttpPost]
        public IHttpActionResult CreateCustomer([FromBody] Customer customer)
        {
            if(string.IsNullOrWhiteSpace(customer.FirstName) || string.IsNullOrWhiteSpace(customer.LastName))
            {
                return BadRequest("Invalid First Name or Last Name");
            }

            var payload = new
            {
                CustomerId = 1,
                Message = "Customer created :)"
            };

            return Ok(payload);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetCustomer([FromUri] int id)
        {
            Customer customer = new Customer
            {
                Id = id,
                FirstName = "Pepe",
                LastName = "Perez"
            };

            return Ok(customer);
        }

        [Route("{name}")]
        [HttpGet]
        public IHttpActionResult GetCustomer([FromUri] string name)
        {
            Customer customer = new Customer
            {
                Id = 1,
                FirstName = name,
                LastName = "Perez"
            };

            return Ok(customer);
        }

        [Route("{id:int}/products")]
        [HttpGet]
        public IHttpActionResult GetCustomerProducts([FromUri] int id)
        {
            //buscar cliente
            //si cliente existe ir por los productos

            var products = new List<Product>
            {
                new Product {Id = 1, Name = "Coca Cola", Price = 10},
                new Product {Id = 2, Name = "Sabritas", Price = 32},
                new Product {Id = 3, Name = "Salsa", Price = 15.5}
            };

            return Ok(products);
        }

        [Route("{customerId:int}/product/{productId:int}")]
        [HttpGet]
        public IHttpActionResult GetCustomerProducts([FromUri] int customerId, [FromUri]int productId)
        {
            //buscar cliente
            //si cliente existe ir por los productos

            Product product = new Product { Id = 1, Name = "Coca Cola", Price = 10 };

            return Ok(product);
        }

    }
}
