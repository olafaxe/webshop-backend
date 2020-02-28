using System;
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
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            using (Context context = new Context())
            {
                List<Order> Orders = context.Orders
                    .Include(c => c.Customer)
                    .Include(or => or.OrderItem)
                        .ThenInclude(or => or.Product)

                    .ToList();
                return Ok(Orders);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<List<Order>> Get(int id)
        {
            using (Context context = new Context())
            {
                Order Order = context.Orders
                    .Include(c => c.Customer)
                    .Include(or => or.OrderItem)
                        .ThenInclude(or => or.Product)
                    .First(o => o.Id == id);
                return Ok(Order);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] OrderViewModel nOrder)
        {
            using (Context context = new Context())
            {
                Customer c = new Customer();
                c.Email = nOrder.Customer.Email;
                c.UserName = nOrder.Customer.UserName;

                context.Customers.Add(c);
                context.SaveChanges();

                Order o = new Order();
                o.OrderDate = DateTime.Now;
                o.CustomerId = c.Id;
                context.Orders.Add(o);
                context.SaveChanges();

                foreach (var item in nOrder.Cart)
                {
                    OrderItem or = new OrderItem();
                    or.OrderId = o.Id;
                    or.ProductId = item.Id;
                    or.Price = item.Price;
                    or.Color = item.Color;
                    context.OrderItem.Add(or);
                    context.SaveChanges();
                }

                return Created("/orders", o);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (Context context = new Context())
            {
                Order deleteOrder = context.Orders.First(o => o.Id == id);
                context.Orders.Remove(deleteOrder);
                context.SaveChanges();
            }
            return Ok();
        }
    }
}