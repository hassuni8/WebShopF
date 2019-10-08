using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ApplicationServices;
using Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebShopFruit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/Customer
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return Ok(_customerService.GetAllCustomers());
        }


        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Customer> Get(int id)
        {
            if (id < 1) return BadRequest("Id has to be higher than 1");
            return _customerService.FindCustomerById(id);
        }

        // POST: api/Customer
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            return _customerService.CreateCustomer(customer);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Customer> Put(int id, [FromBody] Customer customer)
        {
            if (id < 1 || id != customer.Id)
            {
                return BadRequest("The ids must match");
            }

            _customerService.UpdateCustomer(customer);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Customer> Delete(int id)
        {
            Customer cus = _customerService.DeleteCustomer(id);
            if (cus == null)
            {
                return BadRequest("Id must be the same as fruit Id");
            }
            return Ok("Fruit with id: " + id + " has been deleted");
        }
    }
}
