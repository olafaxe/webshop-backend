using System.Collections.Generic;
using System.Linq;
using shopApi.Contexts;
using shopApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace shopApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            using (Context context = new Context())
            {
                List<Customer> Customers = context.Customers.ToList();
                return Ok(Customers);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<List<Order>> Get(int id)
        {
            using (Context context = new Context())
            {
                Customer Customer = context.Customers.First(c => c.Id == id);
                return Ok(Customer);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer newCustomer)
        {
            using (Context context = new Context())
            {
                context.Customers.Add(newCustomer);
                context.SaveChanges();
            }
            return Created("/customers", newCustomer);

        }

    }
}