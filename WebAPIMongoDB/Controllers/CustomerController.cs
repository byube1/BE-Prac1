using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIMongoDB.Models;
using WebAPIMongoDB.Services;

namespace WebAPIMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly CustomerServices _customerServices;

        public CustomerController(CustomerServices customerServices)
        {
            _customerServices = customerServices;
        }


        [HttpGet]
        public ActionResult<List<Customer>> Get() =>
            _customerServices.Get();

        [HttpGet("{id:length(24)}", Name = "GetCustomer")]
        public ActionResult<Customer> Get(string id)
        {
            var customer = _customerServices.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpPost]
        public ActionResult<Customer> Create(Customer customer)
        {
            _customerServices.Create(customer);

            return CreatedAtRoute("GetCustomer", new { id = customer.Id.ToString() }, customer);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Customer customerIn)
        {
            var customer = _customerServices.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            _customerServices.Update(id, customerIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var customer = _customerServices.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            _customerServices.Remove(id);
            return NoContent();
        }
    }
}
